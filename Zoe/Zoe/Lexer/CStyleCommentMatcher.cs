using System;
using System.Text;

namespace Zoe.Lexer {
    public class CStyleCommentMatcher : Matcher{
        
        public CStyleCommentMatcher(int ID) {
            base.ID = ID;
        }


        public override Token Match( Scanner scanner ) {

            if (scanner.Peek(0) != '/' || scanner.Peek(1) != '/'){
                return Token.Invalid;
            }

            TokenPos pos = scanner.Pos;
            scanner.Consume(2);

            StringBuilder comment = new StringBuilder();
            while(true){
                char c = scanner.Peek(0);
                scanner.Consume(1);

                if (c == '\0'){
                    break;
                }

                if (c == '\n'){
                    scanner.ChangeLine();
                    break;
                }
                comment.Append(c);
            }

            return new Token(ID, comment.ToString(), pos);
        }
    }
}
