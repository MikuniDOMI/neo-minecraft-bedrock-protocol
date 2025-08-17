using neo_raknet.Packet;

public class EducationExternalLinkSettings
{
    /// <summary>
    ///     The external link URL.
    /// </summary>
    public string URL { get; set; } = "";

    /// <summary>
    ///     The display name in game.
    /// </summary>
    public string DisplayName { get; set; } = "";
}

public class McpeEducationSettings : Packet
{
    public McpeEducationSettings()
    {
        Id = 137;
        IsMcpe = true;
    }

    /// <summary>
    ///     The default URI that the Code Builder is ran on. Using this, a Code Builder program can make code directly affect
    ///     the server.
    /// </summary>
    public string CodeBuilderDefaultURI { get; set; } = "";

    /// <summary>
    ///     The title of the code builder shown when connected to the CodeBuilderDefaultURI.
    /// </summary>
    public string CodeBuilderTitle { get; set; } = "";

    /// <summary>
    ///     Specifies if clients connected to the world should be able to resize the code builder when it is opened.
    /// </summary>
    public bool CanResizeCodeBuilder { get; set; }

    /// <summary>
    ///     Disables the legacy title bar in the UI.
    /// </summary>
    public bool DisableLegacyTitleBar { get; set; }

    /// <summary>
    ///     The post-process filter applied to the visual effects.
    /// </summary>
    public string PostProcessFilter { get; set; } = "";

    /// <summary>
    ///     The file path to the screenshot border image.
    /// </summary>
    public string ScreenshotBorderPath { get; set; } = "";

    /// <summary>
    ///     Whether players are allowed to modify blocks (optional).
    /// </summary>
    public Optional<bool> CanModifyBlocks { get; set; } = new();

    /// <summary>
    ///     Overrides the default Code Builder URI with a custom one (optional).
    /// </summary>
    public Optional<string> OverrideURI { get; set; } = new();

    /// <summary>
    ///     Specifies if the world has a quiz connected to it.
    /// </summary>
    public bool HasQuiz { get; set; }

    /// <summary>
    ///     External link settings for educational resources (optional).
    /// </summary>
    public Optional<EducationExternalLinkSettings> ExternalLinkSettings { get; set; } = new();

    protected override void EncodePacket()
    {
        base.EncodePacket();
        Write(CodeBuilderDefaultURI);
        Write(CodeBuilderTitle);
        Write(CanResizeCodeBuilder);
        Write(DisableLegacyTitleBar);
        Write(PostProcessFilter);
        Write(ScreenshotBorderPath);

        // Optional<bool> - CanModifyBlocks
        Write(CanModifyBlocks.HasValue);
        if (CanModifyBlocks.HasValue) Write(CanModifyBlocks.Value);

        // Optional<string> - OverrideURI
        Write(OverrideURI.HasValue);
        if (OverrideURI.HasValue) Write(OverrideURI.Value);

        Write(HasQuiz);

        // Optional<EducationExternalLinkSettings>
        Write(ExternalLinkSettings.HasValue);
        if (ExternalLinkSettings.HasValue)
        {
            Write(ExternalLinkSettings.Value.URL);
            Write(ExternalLinkSettings.Value.DisplayName);
        }
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();
        CodeBuilderDefaultURI = ReadString();
        CodeBuilderTitle = ReadString();
        CanResizeCodeBuilder = ReadBool();
        DisableLegacyTitleBar = ReadBool();
        PostProcessFilter = ReadString();
        ScreenshotBorderPath = ReadString();

        // Optional<bool> - CanModifyBlocks
        CanModifyBlocks.HasValue = ReadBool();
        if (CanModifyBlocks.HasValue) CanModifyBlocks.Value = ReadBool();

        // Optional<string> - OverrideURI
        OverrideURI.HasValue = ReadBool();
        if (OverrideURI.HasValue) OverrideURI.Value = ReadString();

        HasQuiz = ReadBool();

        // Optional<EducationExternalLinkSettings>
        ExternalLinkSettings.HasValue = ReadBool();
        if (ExternalLinkSettings.HasValue)
        {
            var settings = new EducationExternalLinkSettings();
            settings.URL = ReadString();
            settings.DisplayName = ReadString();
            ExternalLinkSettings.Value = settings;
        }
    }
}