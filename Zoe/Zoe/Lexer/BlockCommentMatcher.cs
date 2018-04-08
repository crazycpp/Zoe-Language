using System;
using System.Text;

namespace Zoe.Lexer {
    public class BlockCommentMatcher : Matcher{

        public BlockCommentMatcher(int ID) {
            base.ID = ID;
            base.Name = "COMMENT";
        }

        public override Token Match( Scanner scanner ) {
            if (scanner.Peek(0) != '/' || scanner.Peek(1) != '1'){
                return Token.Invalid;
            }

            TokenPos pos = scanner.Pos;
            scanner.Consume(2);
            StringBuilder comment = new StringBuilder();
            while(scanner.Peek(0) != '*' || scanner.Peek(2) != '/'){
                char c = scanner.Peek(0);

                comment.Append(c);
                scanner.Consume(1);

            }

            scanner.Consume(2);


            return new Token(ID, comment.ToString(), pos);
        }
    }
}
