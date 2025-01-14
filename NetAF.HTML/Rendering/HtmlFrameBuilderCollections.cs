using NetAF.Rendering.Console;
using NetAF.Rendering.Console.FrameBuilders;

namespace NetAF.Rendering.FrameBuilders
{
    /// <summary>
    /// Provides a container for HTML frame builder collections.
    /// </summary>
    public static partial class HtmlFrameBuilderCollections
    {
        /// <summary>
        /// Get the default frame builder collection.
        /// </summary>
        public static FrameBuilderCollection Default
        {
            get
            {
                var gridLayoutBuilder = new GridStringBuilder();
                var htmlBuilder = new HtmlBuilder();

                IFrameBuilder[] frameBuilders =
                [
                    new HtmlTitleFrameBuilder(htmlBuilder),
                    new ConsoleSceneFrameBuilder(gridLayoutBuilder, new ConsoleRoomMapBuilder(gridLayoutBuilder)),
                    new ConsoleRegionMapFrameBuilder(gridLayoutBuilder, new ConsoleRegionMapBuilder(gridLayoutBuilder)),
                    new ConsoleCommandListFrameBuilder(gridLayoutBuilder),
                    new ConsoleHelpFrameBuilder(gridLayoutBuilder),
                    new ConsoleCompletionFrameBuilder(gridLayoutBuilder),
                    new ConsoleGameOverFrameBuilder(gridLayoutBuilder),
                    new ConsoleAboutFrameBuilder(gridLayoutBuilder),
                    new ConsoleReactionFrameBuilder(gridLayoutBuilder),
                    new ConsoleConversationFrameBuilder(gridLayoutBuilder)
                ];

                return new(frameBuilders);
            }
        }
    }
}
