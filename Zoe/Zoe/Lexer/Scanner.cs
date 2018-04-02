using System;
namespace Zoe.Lexer {
    public class Scanner {

        private int _Col;
        private int _Line;
        private int _ReadedCount;

        private string _Source;
        private string _FileName;

        public Scanner() {
            _Col = 0;
            _Line = 0;
            _ReadedCount = 0;
        }

        public bool IsEof(int Count){
            return _ReadedCount + Count >= _Source.Length;
        }
    }
}
