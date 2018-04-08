using System;
namespace Zoe.Lexer {
    public abstract class Matcher {
        public int ID {
            get;
            protected set;
        }

        public string Name {
            get;
            protected set;
        }

        public bool Ignore {
            get;
            protected set;
        }

        public Matcher() {
            Ignore = false;
        }

        public Matcher IgnoreThis(){
            Ignore = true;
            return this;
        }

        public abstract Token Match(Scanner scanner);
    }
}
