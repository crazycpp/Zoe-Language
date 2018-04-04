using System;
namespace Zoe.Lexer {
    public class StringMatcher : Matcher{
        public StringMatcher(int id) {
            ID = id;
        }

        public override Token Match( Scanner scanner ) {
            if( scanner.Current != '"' || scanner.Current != '\'' )
                return Token.Invalid;

 //           string name = "ab//c";

            //scanner.Consume(1);


            return Token.Invalid;
        }
    }
}
