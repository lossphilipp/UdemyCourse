using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
    public class CodeField
    {
        public string Name;
        public string Type;

        public CodeField()
        {

        }

        public CodeField(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"public {Type} {Name};";
        }
    }
    public class CodeClass
    {
        public string Name;
        public List<CodeField> Fields = new List<CodeField>();

        public CodeClass()
        {

        }

        public CodeClass(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"public class {Name}");
            sb.AppendLine("{");

            foreach (CodeField field in Fields)
            {
                sb.AppendLine($"  {field}");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
    }


    public class CodeBuilder
    {
        private readonly string classname;
        CodeClass newClass = new CodeClass();

        public CodeBuilder(string classname)
        {
            this.classname = classname;
            newClass.Name = classname;
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            CodeField field = new CodeField(fieldName, fieldType);
            newClass.Fields.Add(field);
            return this;
        }

        public override string ToString()
        {
            return newClass.ToString();
        }

        public void Clear()
        {
            newClass = new CodeClass() { Name = classname };
        }
    }
}
