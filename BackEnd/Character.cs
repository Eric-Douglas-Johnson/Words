
namespace Permutation.BackEnd
{
    public class Character
    {
        public int Index { get; set; }
        public char Value { get; set; }
        public bool WasUsedInContext { get; set; }

        public Character(int index,  char value)
        {
            Index = index;
            Value = value;
        }
    }
}
