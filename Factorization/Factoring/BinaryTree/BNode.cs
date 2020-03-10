using Factorization.NumberTypes.Interfaces;

namespace Factorization.Factoring.BinaryTree
{
    //The following class was created by the user fubo (https://stackoverflow.com/users/1315444/fubo) post on stackoverflow.com
    //Stackoverflow post: https://stackoverflow.com/questions/36311991/c-sharp-display-a-binary-search-tree-in-console
    public class BNode
    {
        public long value;
        public BNode right;
        public BNode left;
            
        public BNode(IFactor factor)
        {
            this.value= factor.Value;
        }
    }
}