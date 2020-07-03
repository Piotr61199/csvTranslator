namespace Translator
{
    public class TextModel
    {
        public int IdText { get; set; }
        public int IdFile { get; set; }
        public int RowNum { get; set; }
        public string ColumnName { get; set; }
        public string PrimaryLanguage { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string Language3 { get; set; }
        public string Language4 { get; set; }
        public string Language5 { get; set; }
        public string Language6 { get; set; }
        public string Language7 { get; set; }
        public string Language8 { get; set; }
        public string Language9 { get; set; }
    }
    public class FileModel
    {
        public int IdFile { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string FullPath
        {
            get
            {
                var s = @"\";
                return $"{ Path }{s}{ Name }";
            }
        }
    }
    public class LanguageModel
    {
        public int Code { get; set; }
        public string String { get; set; }
        public string Text { get; set; }
        public string FullName
        {
            get
            {

                return Text + " (" + Code + ")";
            }
        }
    }


}
