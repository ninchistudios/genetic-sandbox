using System;

namespace ninjachimpstudios {

    public class Gene {

        public Gene() { }

        // copy constructor, no logic
        public Gene(Gene other) {
            this.Descriptor = other.Descriptor;
            this.minvalue = other.minvalue;
            this.maxvalue = other.maxvalue;
            this.value = other.value;
        }

        public string Descriptor { get; private set; }
        public int minvalue { get; private set; } = 0;
        public int maxvalue { get; private set; } = 255;
        public int value { get; private set; } = 128;

    }

}