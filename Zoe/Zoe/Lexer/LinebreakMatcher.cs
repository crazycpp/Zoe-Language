using System;
using System.Text;

namespace Zoe.Lexer {

    public class LinebreakMatcher : Matcher {

        public LinebreakMatcher(int id ) {
            base.ID = id;
            base.Name = string.Empty;
        }

        public override Token Match( Scanner scanner ) {

            // 在windows系统里面, \r\n为换行
            // 在Unix/Mac下,  \n为换行

            TokenPos pos = TokenPos.InitPos;

            var content = new StringBuilder();

            while(true) {
                var c = scanner.Peek(0);
                if(c == '\n') {
                    if(pos.Equals(TokenPos.InitPos)) {
                        pos = scanner.Pos;
                    }
                    content.Append( c );
                    scanner.ChangeLine();
                    //scanner.Consume(1);
                    continue;
                }
                else if(c == '\r') {
                    content.Append( c );
                    scanner.Consume( 1 );
                    continue;
                }

                break;
            }

            if(pos.Equals(TokenPos.InitPos)) {
                return Token.Invalid;
            }

            return new Token(ID, content.ToString(), pos);
        }
    }
}