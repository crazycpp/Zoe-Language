using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoe.Parser {
    enum TokenType {
        Token_Whitespace,
        Token_Linebreak,
        Token_Number,
        Token_Sign,
        Token_Keywork,
        Token_Ident,
        Token_Unknow,
    }
}
