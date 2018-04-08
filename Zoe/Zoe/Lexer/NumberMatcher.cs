using System;
using System.Text;

namespace Zoe.Lexer {
    public class NumberMatcher : Matcher {

        StringBuilder _Content = new StringBuilder();

        public NumberMatcher(int id) {
            base.ID = id;
            base.Name = "NumberMatcher";
        }


        public override Token Match( Scanner scanner ) {
            
            if( !(char.IsDigit(scanner.Current) || scanner.Current == '-' && char.IsDigit(scanner.Peek(1))) )
                return Token.Invalid;

            TokenPos pos = scanner.Pos;

            _Content.Clear();
            bool encounterDot = false;
            while(true){
                _Content.Append(scanner.Current);
                scanner.Consume(1);
                if (!char.IsDigit(scanner.Current)){

                    if( scanner.Current == '.' )
                        encounterDot = true;
                    break;
                }
            }

            // if encounter Dot is true that means it's a float number
            if (encounterDot){
                int index = 0;
                while(true){
                    _Content.Append(scanner.Current);
                    scanner.Consume(1);
                    if (!char.IsDigit(scanner.Current)){
                        if( index == 0 )
                            throw new Exception("illegal float number: " + pos.ToString());

                        break;
                    }

                    index++;
                }
            }

            return new Token(ID, _Content.ToString(), pos);
        }
    }
}
