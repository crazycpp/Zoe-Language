using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoe.Lexer {
    class WhitespaceMatcher : Matcher {

        public WhitespaceMatcher(int id) {
            base.ID = id;
            base.Name = string.Empty;
        }

        bool IsWhitespaceChar(char c) {
            return c == ' ' || c == '\t';
        }

        public override Token Match( Scanner scanner) {
            int count = 0;
            while(true) {
                var c = scanner.Peek(count);
                if(IsWhitespaceChar(c)) {
                    count++;
                    continue;
                }
                break;
            }

            if(count == 0) {
                return Token.Invalid;
            }

            var tokenPos = scanner.Pos;
            var index = scanner.ReadedCount;
            scanner.Consume( count );
            var tokenValue = scanner.Source.Substring( index, count );
            return new Token( ID, tokenValue, tokenPos );
        }
    }
}
