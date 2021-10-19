using PanGu.Dictionaries;
using PanGu.Framework;
using PanGu.Settings;

namespace PanGu.Match
{

    /// <summary>
    /// interface for Chinese full text match 
    /// </summary>
    public interface IChsFullTextMatch
    {
        MatchOption Options { get; set; }

        MatchParameter Parameters { get; set; }

        /// <summary>
        /// Do match
        /// </summary>
        /// <param name="positionLenArr">array of position length</param>
        /// <param name="count">count of items of position length list</param>
        /// <returns>Word Info list</returns>
        SuperLinkedList<WordInfo> Match(PositionLength[] positionLenArr, string orginalText, int count);

    }
}
