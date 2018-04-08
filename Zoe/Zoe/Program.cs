using System;
using System.Collections.Generic;
using Zoe.Lexer;
using Zoe.Parser;

namespace Zoe {
    class MainClass {
        public static void Main( string[] args ) {

            string code = "class bird\nfunc init { y=100 z = -6.601 \nx=y+z\n }";

            Lexer.Lexer lexer = new Lexer.Lexer();
            lexer.AddMatcher( new LinebreakMatcher( (int)TokenType.Token_Whitespace).IgnoreThis() );
            lexer.AddMatcher( new WhitespaceMatcher( (int) TokenType.Token_Linebreak).IgnoreThis() );

            // number
            lexer.AddMatcher(new NumberMatcher((int)TokenType.Token_Number));

            // sign
            lexer.AddMatcher(new SignMatcher((int)TokenType.Token_Sign, "="));
            lexer.AddMatcher(new SignMatcher((int)TokenType.Token_Sign, "+"));
            lexer.AddMatcher(new SignMatcher((int)TokenType.Token_Sign, "-"));
            lexer.AddMatcher(new SignMatcher((int)TokenType.Token_Sign, "{"));
            lexer.AddMatcher(new SignMatcher((int)TokenType.Token_Sign, "}"));


            // keyword Matcher
            lexer.AddMatcher( new KeywordMatcher((int)TokenType.Token_Keywork, "func") );
            lexer.AddMatcher( new KeywordMatcher( (int)TokenType.Token_Keywork, "var" ) );
            lexer.AddMatcher( new KeywordMatcher((int)TokenType.Token_Keywork, "class"));

            lexer.AddMatcher( new IdentifierMatcher((int)TokenType.Token_Ident));


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
