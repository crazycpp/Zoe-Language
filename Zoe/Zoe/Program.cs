using System;
using System.Collections.Generic;
using Zoe.Lexer;
using Zoe.Parser;

namespace Zoe {
    class MainClass {
        public static void Main( string[] args ) {

            string code = "func \nvar";

            Lexer.Lexer lexer = new Lexer.Lexer();
            lexer.AddMatcher( new LinebreakMatcher( (int)TokenType.Token_Whitespace ) );
            lexer.AddMatcher(new WhitespaceMatcher( (int) TokenType.Token_Linebreak));
            lexer.AddMatcher(new KeywordMatcher((int)TokenType.Token_Keywork, "func"));
            lexer.AddMatcher( new KeywordMatcher( (int)TokenType.Token_Keywork, "var" ) );

            lexer.Init(code, "hello.zs");

            List<Token> tokenList = new List<Token>();

            while(true) {
                Token token = lexer.Scan();
                if(!token.IsInvalid)
                    break;

                tokenList.Add(token);
            }

            foreach(var token in tokenList ) {
                Console.WriteLine(token.ToString());
            }
        }
    }
}
