using System;
namespace Zoe.Lexer {
    /// <summary>
    /// 源码扫描器
    /// </summary>
    public class Scanner {

        public string Source {
            get;
            set;
        }

        public int ReadedCount
        {
            get;
            private set;
        }

        public int RemainCount {
            get { return Source.Length-ReadedCount; }
        }

        public TokenPos Pos = TokenPos.InitPos;

        public Scanner() {

            ReadedCount = 0;
            _ = TokenPos.InitPos;
        }

        public void Init(string source, string fileName) {
            Source = source;
            Pos.FileName = fileName;
        }

        public char Peek(int count) {
            if(IsEof(count))
                return '\0';

            return Source[ReadedCount + count];
        }

        public void Consume(int count) {
            Pos.Col += count;
            ReadedCount += count;
        }

        public void ChangeLine() {
            Pos.Col = 1;
            Pos.Line++;
            ReadedCount++;
        }

        public bool IsEof(int Count){
            return ReadedCount + Count >= Source.Length;
        }
    }
}
