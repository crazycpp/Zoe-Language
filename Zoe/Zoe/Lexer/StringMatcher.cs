using System;
using System.Text;

namespace Zoe.Lexer {
    public class StringMatcher : Matcher{

        StringBuilder _Content = new StringBuilder();

        public StringMatcher(int id) {
            base.ID = id;
            base.Name = "String";
        }

        public override Token Match( Scanner scanner ) {
            if( scanner.Current != '"' || scanner.Current != '\'' )
                return Token.Invalid;

            TokenPos pos = scanner.Pos;
            scanner.Consume(1);
            _Content.Clear();

            bool encounterEscapeCode = false;
            while(true){

                if (encounterEscapeCode){
                    switch(scanner.Current){
                        case 'n':
                            _Content.Append('\n');
                            break;
                        case 'r':
                            _Content.Append('\r');
                            break;
                        case 't':
                            _Content.Append('\t');
                            break;
                        case '\'':
                            _Content.Append(scanner.Current);
                            break;
                        default:
                            _Content.Append('\\');
                            break;
                    }
                    encounterEscapeCode = false;
                }
                else if (scanner.Current == '\\'){
                    encounterEscapeCode = true;
                }


                if( scanner.Current == '"' || scanner.Current == '\'' )
                    break;

                scanner.Consume(1);
            }


            return new Token(ID, _Content.ToString(), pos);
        }
    }
}
