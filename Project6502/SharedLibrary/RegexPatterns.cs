namespace SharedLibrary
{
    public static class RegexPatterns
    {
        public const string Absolute = @"^\$([\dA-Z]{4})(?:\Z|\r)";
        public const string AbsoluteX = @"^\$([\dA-Z]{4}), *X(?:\Z|\r)";
        public const string AbsoluteY = @"^\$([\dA-Z]{4}), *Y(?:\Z|\r)";
        public const string Immediate = @"^#\$([\dA-Z]{2})(?:\Z|\r)";
        public const string ZP = @"\$([\dA-Z]{2})(?:\Z|\r)";
        public const string ZPX = @"\$([\dA-Z]{2}), *X(?:\Z|\r)";
        public const string ZPXIndirect = @"\(\$([\dA-Z]{2}), *X\)(?:\Z|\r)";
        public const string ZPIndirectY = @"\(\$([\dA-Z]{2})\), *Y(?:\Z|\r)";
    }
}
