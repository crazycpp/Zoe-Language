using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoe.Lexer {
    class UnknowMatcher :Matcher{

        public UnknowMatcher(int id) {
            base.ID = id;
            base.Name = "UnKnowMatcher";
        }


        public override Token Match( Scanner scanner ) {

            var tokenPos = scanner.Pos;
            var index = scanner.ReadedCount;
            scanner.Consume(1);
            return new Token(ID, scanner.Source.Substring(index, 1), tokenPos );
        }
    }
}
