namespace neo_raknet.Packet.MinecraftPacket;

public class McpeDisconnect : Packet
{
    public enum DisconnectReason
    {
        Unknown = 0,
        CantConnectNoInternet,
        NoPermissions,
        UnrecoverableError,
        ThirdPartyBlocked,
        ThirdPartyNoInternet,
        ThirdPartyBadIP,
        ThirdPartyNoServerOrServerLocked,
        VersionMismatch,
        SkinIssue,
        InviteSessionNotFound,
        EduLevelSettingsMissing,
        LocalServerNotFound,
        LegacyDisconnect,
        UserLeaveGameAttempted,
        PlatformLockedSkinsError,
        RealmsWorldUnassigned,
        RealmsServerCantConnect,
        RealmsServerHidden,
        RealmsServerDisabledBeta,
        RealmsServerDisabled,
        CrossPlatformDisabled,
        CantConnect,
        SessionNotFound,
        // 跳过了一个值 (26)
        ServerFull = 27,
        InvalidPlatformSkin,
        EditionVersionMismatch,
        EditionMismatch,
        LevelNewerThanExeVersion,
        NoFailOccurred,
        BannedSkin,
        Timeout,
        ServerNotFound,
        OutdatedServer,
        OutdatedClient,
        // 跳过了一个值 (38)
        MultiplayerDisabled = 39,
        NoWiFi,
        // 跳过了一个值 (41)
        NoReason = 42,
        Disconnected,
        InvalidPlayer,
        LoggedInOtherLocation,
        ServerIdConflict,
        NotAllowed,
        NotAuthenticated,
        InvalidTenant,
        UnknownPacket,
        UnexpectedPacket,
        InvalidCommandRequestPacket,
        HostSuspended,
        LoginPacketNoRequest,
        LoginPacketNoCert,
        MissingClient,
        Kicked,
        KickedForExploit,
        KickedForIdle,
        ResourcePackProblem,
        IncompatiblePack,
        OutOfStorage,
        InvalidLevel,
        // 跳过了一个值 (67)
        BlockMismatch = 68,
        InvalidHeights,
        InvalidWidths,
        // 跳过了两个值 (71, 72)
        Shutdown = 73,
        // 跳过了一个值 (74)
        LoadingStateTimeout = 75,
        ResourcePackLoadingFailed,
        SearchingForSessionLoadingScreenFailed,
        NetherNetProtocolVersion,
        SubsystemStatusError,
        EmptyAuthFromDiscovery,
        EmptyUrlFromDiscovery,
        ExpiredAuthFromDiscovery,
        UnknownSignalServiceSignInFailure,
        XBLJoinLobbyFailure,
        UnspecifiedClientInstanceDisconnection,
        NetherNetSessionNotFound,
        NetherNetCreatePeerConnection,
        NetherNetICE,
        NetherNetConnectRequest,
        NetherNetConnectResponse,
        NetherNetNegotiationTimeout,
        NetherNetInactivityTimeout,
        StaleConnectionBeingReplaced,
        // 跳过了一个值 (97)
        BadPacket = 98,
        NetherNetFailedToCreateOffer,
        NetherNetFailedToCreateAnswer,
        NetherNetFailedToSetLocalDescription,
        NetherNetFailedToSetRemoteDescription,
        NetherNetNegotiationTimeoutWaitingForResponse,
        NetherNetNegotiationTimeoutWaitingForAccept,
        NetherNetIncomingConnectionIgnored,
        NetherNetSignalingParsingFailure,
        NetherNetSignalingUnknownError,
        NetherNetSignalingUnicastDeliveryFailed,
        NetherNetSignalingBroadcastDeliveryFailed,
        NetherNetSignalingGenericDeliveryFailed,
        EditorMismatchEditorWorld,
        EditorMismatchVanillaWorld,
        WorldTransferNotPrimaryClient,
        RequestServerShutdown,
        ClientGameSetupCancelled,
        ClientGameSetupFailed,
        // 跳过了一个值 (119)
        NetherNetSignalingSigninFailed = 120,
        SessionAccessDenied,
        ServiceSigninIssue,
        NetherNetNoSignalingChannel,
        NetherNetNotLoggedIn,
        NetherNetClientSignalingError,
        SubClientLoginDisabled,
        DeepLinkTryingToOpenDemoWorldWhileSignedIn,
        AsyncJoinTaskDenied,
        RealmsTimelineRequired,
        GuestWithoutHost,
        FailedToJoinExperience,
        NetherNetDataChannelClosed
    }
    public DisconnectReason failReason; // = null;
    public string filteredMessage; // = null

    public bool hideDisconnectReason; // = null;
    public string message; // = null;

    public McpeDisconnect()
    {
        Id = 0x05;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(0); //todo
        Write(hideDisconnectReason);
        Write(message);
        Write(filteredMessage);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        failReason = (DisconnectReason)ReadUnsignedVarInt();
        hideDisconnectReason = ReadBool();
        message = ReadString();
        filteredMessage = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        hideDisconnectReason = default;
        message = default;
        failReason = default(int);
    }
}