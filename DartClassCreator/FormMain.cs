using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DartClassCreator
{
    public partial class FormMain : Form
    {
        public class Field
        {
            public string Type;
            public string Name;
        }

        private List<string> defaultTypes = new List<string>() {"int", "double", "String", "bool", "num"};

        private List<Field> ParseFields(string[] fieldsStr)
        {
            List<Field> fields = new();
            foreach (var str in fieldsStr)
            {
                fields.Add(new Field
                {
                    Name = str.Split(' ')[0],
                    Type = str.Split(' ')[1],
                });
            }

            return fields;
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            var className = textBoxClassName.Text;
            var fields = ParseFields(richTextBoxFields.Text.Split('\n', StringSplitOptions.RemoveEmptyEntries));
            var result = GenerateCode(className, fields);

            richTextBoxGeneratedCode.Text = result;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private string GenerateConstructor(string className, List<Field> fields)
        {
            return $"\t{className}({{\n" +
                   $"\t\t{string.Join(",\n\t\t", fields.Select(f => $"required this.{f.Name}"))}\n" +
                   $"\t}})";
        }

        //name type
        //coords LatLng 
        //offices List<Office>


        private bool checkList(Field field)
        {
            return field.Type.Contains("List");
        }

        private bool checkComplexField(Field field)
        {
            return !defaultTypes.Exists(dt => dt == field.Type);
        }

        private string GetListType(Field field)
        {
            return field.Type.Replace("List<", "").Trim('>');
        }

        private string GenerateComplexFieldFromJson(Field field)
        {
            return $"{field.Name}: {field.Type}.FromJson(json[\'{field.Name}\'] as Map<String, dynamic>)";
        }

        private string GenerateListFieldFromJson(Field field)
        {
            return
                $"{field.Name}: (json[\'{field.Name}\'] as List<dinamic>).map((e)=> {GetListType(field)}.fromJson(e as Map<String, dynamic>)).toList()";
        }

        private string GenerateFromJson(string className, List<Field> fields)
        {
            return $"\treturn {className}(\n" +
                   $"\t\t{string.Join(",\n\t\t", fields.Select(f => { if (checkList(f)) { return GenerateListFieldFromJson(f); } else if (checkComplexField(f)) { return GenerateComplexFieldFromJson(f); } else { if (f.Type == "num") { return $"{f.Name}: (json[\'{f.Name}\'] as num).toDouble"; } } return $"{f.Name}: json['{f.Name}'] as {f.Type}"; }))}\n" +
                   $"\t\t);\n";
        }


        private string GenerateToJson(List<Field> fields)
        {
            return $"{{\n" +
                   $"\t{string.Join(",\n\t", fields.Select(f => $"'{f.Name}': this.{f.Name}"))}\n" +
                   $"}};";
        }

        private string GenerateFinalFields(List<Field> fields)
        {
            return $"{string.Join(";\n", fields.Select(f => $"final {(f.Type=="num" ? "double" : f.Type)} {f.Name}"))}";
        }

        private string GenerateCode(string className, List<Field> fields)
        {
            string result =
                $"@JsonSerializable()\n" +
                $"class {className} {{\n" +
                $"{GenerateConstructor(className, fields)}\n" +
                $"}}\n\n" +
                $"factory {className}.fromJson(Map<String, dynamic> json) {{\n" +
                $"{GenerateFromJson(className, fields)}" +
                $"\t}}\n\n" +
                $"Map<String, dynamic> toJson() => <String, dynamic>" +
                $"{GenerateToJson(fields)}\n\n" +
                $"{GenerateFinalFields(fields)};\n" +
                $"}}";
            return result;
        }
    }
}