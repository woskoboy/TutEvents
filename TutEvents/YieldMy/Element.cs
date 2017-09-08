namespace YieldMy
{
    internal class Element
    {
        public Element(string field, int field1, int field2)
        {
            this.Field = field;
            this.Field1 = field1;
            this.Field2 = field2;
        }

        public string Field { get; private set; }
        public int Field1 { get; private set; }
        public int Field2 { get; private set; }
    }
}