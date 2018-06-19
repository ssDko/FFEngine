using System.Collections.Generic;

namespace TiledEngine
{
    static public class TiledHelperMethods
    {
        #region Constants
        const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
        const uint FLIPPED_VERTICALLY_FLAG   = 0x40000000;
        const uint FLIPPED_DIAGONALLY_FLAG   = 0x20000000;
        #endregion

        #region Methods

        static public int ConvertGIDToID(uint gID, List<uint> firstGlobalIDs = null)
        {
            int id = (int)(gID & ~(FLIPPED_HORIZONTALLY_FLAG | FLIPPED_VERTICALLY_FLAG | FLIPPED_DIAGONALLY_FLAG));

            if (firstGlobalIDs != null)
            {
                for (int i = firstGlobalIDs.Count - 1; i >= 0; i--)
                {
                    if (id >= firstGlobalIDs[i])
                    {
                        id -= (int)firstGlobalIDs[i];
                        break; // We should have the id we want
                    }
                }
            }

            return id;
        }

        static public int GetTileSetIndex(uint gID, List<uint> firstGlobalIDs)
        {
            int index = firstGlobalIDs.Count - 1;
            int id = ConvertGIDToID(gID);

            for (int i = firstGlobalIDs.Count - 1; i >= 0; i--)
            {
                if (id >= firstGlobalIDs[i])
                {
                    return index;
                }
                else
                {
                    index--;
                }
            }

            return -1; // Error
        }

        static public uint ConvertIDToGID(int ID, bool hFlip, bool vFlip, bool dFlip, uint firstGlobalID = 1)
        {
            uint gID = (uint)(ID + firstGlobalID);

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

            test &= FLIPPED_VERTICALLY_FLAG;

            if (test == FLIPPED_VERTICALLY_FLAG)
                return true;
            else
                return false;
        }

        static public bool isGIDDiagonallyFlipped(uint gID)
        {
            uint test = gID;

            test &= FLIPPED_DIAGONALLY_FLAG;

            if (test == FLIPPED_DIAGONALLY_FLAG)
                return true;
            else
                return false;
        }

        #endregion
    }
}
