namespace Tiled_Engine
{
    static public class TiledHelperMethods
    {
        #region Constants
        const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
        const uint FLIPPED_VERTICALLY_FLAG   = 0x40000000;
        const uint FLIPPED_DIAGONALLY_FLAG   = 0x20000000;
        #endregion

        #region Methods

        static public int ConvertGIDToID(uint gID)
        {
            int id = (int)(gID & ~(FLIPPED_HORIZONTALLY_FLAG | FLIPPED_VERTICALLY_FLAG | FLIPPED_DIAGONALLY_FLAG));
            return id;
        }

        static public uint ConvertIDToGID(int ID, bool hFlip, bool vFlip, bool dFlip)
        {
            uint gID = (uint)ID;

            // Add in flags
            SetAllGIDFlipFlags(ref gID, hFlip, vFlip, dFlip);

            return gID;

        }

        static public void SetGIDHorizontalFlipFlag(ref uint gID, bool flagOn)
        {
            if (flagOn)
            {
                gID |= FLIPPED_HORIZONTALLY_FLAG;
            }
            else
            {
                gID &= ~(FLIPPED_HORIZONTALLY_FLAG);
            }
        }

        static public void SetGIDVerticalFlipFlag(ref uint gID, bool flagOn)
        {
            if (flagOn)
            {
                gID |= FLIPPED_VERTICALLY_FLAG;
            }
            else
            {
                gID &= ~(FLIPPED_VERTICALLY_FLAG);
            }
        }

        static public void SetGIDDiagonalFlipFlag(ref uint gID, bool flagOn)
        {
            if (flagOn)
            {
                gID |= FLIPPED_DIAGONALLY_FLAG;
            }
            else
            {
                gID &= ~(FLIPPED_DIAGONALLY_FLAG);
            }
        }

        static public void SetAllGIDFlipFlags(ref uint gID, bool hFlip, bool vFlip, bool dFlip)
        {
            SetGIDHorizontalFlipFlag(ref gID, hFlip);
            SetGIDVerticalFlipFlag(ref gID, vFlip);
            SetGIDDiagonalFlipFlag(ref gID, dFlip);

        }

        static public bool isGIDHorizontallyFlipped(uint gID)
        {
            uint test = gID;
                        
            test &= FLIPPED_HORIZONTALLY_FLAG;

            if (test == FLIPPED_HORIZONTALLY_FLAG)
                return true;
            else
                return false;           
        }

        static public bool isGIDVerticallyFlipped(uint gID)
        {
            uint test = gID;

            test &= FLIPPED_DIAGONALLY_FLAG;

            if (test == FLIPPED_DIAGONALLY_FLAG)
                return true;
            else
                return false;
        }

        static public bool isGIDDiagonallyFlipped(uint gID)
        {
            uint test = gID;

            test &= FLIPPED_VERTICALLY_FLAG;

            if (test == FLIPPED_VERTICALLY_FLAG)
                return true;
            else
                return false;
        }

        #endregion
    }
}
