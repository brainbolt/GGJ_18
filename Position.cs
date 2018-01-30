using System;

namespace GGJ_18
{
    class Position
    {
        public int FromTop { get; set; }
        public int FromLeft { get; set; }
        
        public Position(int fromLeft, int fromTop)
        {
            FromTop = fromTop;
            FromLeft = fromLeft;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var objAsPosition = obj as Position;
            if (objAsPosition == null)
            {
                return false;
            }

            return objAsPosition.FromTop == FromTop && objAsPosition.FromLeft == FromLeft;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + FromTop.GetHashCode();
                hash = hash * 23 + FromLeft.GetHashCode();

                return hash;
            }
        }
    }
}
