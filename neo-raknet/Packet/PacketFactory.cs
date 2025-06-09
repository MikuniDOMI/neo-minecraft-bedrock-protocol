using neo_raknet.Packet.MinecraftPacket;
using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet
{
	public static class PacketFactory
	{
		public static Packet translatePacket(int id, ReadOnlyMemory<byte> buffer, bool raknet = false)
		{
			if (raknet)
			{
				switch (id)
				{
					case 0x00:
						return new ConnectedPing().Decode(buffer);
					case 0x01:
						return new UnconnectedPing().Decode(buffer);
					case 0x03:
						return new ConnectedPong().Decode(buffer);
					case 0x04:
						return new DetectLostConnections().Decode(buffer);
					case 0x1c:
						return new UnconnectedPong().Decode(buffer);
					case 0x05:
						return new OpenConnectionRequest1().Decode(buffer);
					case 0x06:
						return new OpenConnectionReply1().Decode(buffer);
					case 0x07:
						return new OpenConnectionRequest2().Decode(buffer);
					case 0x08:
						return new OpenConnectionReply2().Decode(buffer);
					case 0x09:
						return new ConnectionRequest().Decode(buffer);
					case 0x10:
						return new ConnectionRequestAccepted().Decode(buffer);
					case 0x13:
						return new NewIncomingConnection().Decode(buffer);
					case 0x14:
						return new NoFreeIncomingConnections().Decode(buffer);
					case 0x15:
						return new DisconnectionNotification().Decode(buffer);
					case 0x17:
						return new ConnectionBanned().Decode(buffer);
					case 0x1A:
						return new IpRecentlyConnected().Decode(buffer);
					case 0xfe:
						return new McpeWrapper().Decode(buffer);
					default:
						return new UnknownPacket((byte)id, buffer);
				}
			}
			else
			{
				switch (id)
				{
					case 0x01:
						return new McpeLogin().Decode(buffer);
					case 0x02:
						return new McpePlayStatus().Decode(buffer);
					case 0x03:
						return new McpeServerToClientHandshake().Decode(buffer);
					case 0x04:
						return new McpeClientToServerHandshake().Decode(buffer);
					case 0x05:
						return new McpeDisconnect().Decode(buffer);
					case 0x06:
						return new McpeResourcePacksInfo().Decode(buffer);
					case 0x07:
						return new McpeResourcePackStack().Decode(buffer);
					case 0x08:
						return new McpeResourcePackClientResponse().Decode(buffer);
					case 0x09:
						return new McpeText().Decode(buffer);
					case 0x0a:
						return new McpeSetTime().Decode(buffer);
					case 0x0b:
						return new McpeStartGame().Decode(buffer);
					case 0x0c:
						return new McpeAddPlayer().Decode(buffer);
					case 0x0d:
						return new McpeAddEntity().Decode(buffer);
					case 0x0e:
						return new McpeRemoveEntity().Decode(buffer);
					case 0x0f:
						return new McpeAddItemEntity().Decode(buffer);
					case 0x11:
						return new McpeTakeItemEntity().Decode(buffer);
					case 0x12:
						return new McpeMoveEntity().Decode(buffer);
					case 0x13:
						return new McpeMovePlayer().Decode(buffer);
					case 0x14:
						return new McpeRiderJump().Decode(buffer);
					case 0x15:
						return new McpeUpdateBlock().Decode(buffer);
					case 0x16:
						return new McpeAddPainting().Decode(buffer);
					case 0x17:
					case 0x18:
					//Deprecated McpeLevelSoundEventOld
					case 0x19:
						return new McpeLevelEvent().Decode(buffer);
					case 0x1a:
						return new McpeBlockEvent().Decode(buffer);
					case 0x1b:
						return new McpeEntityEvent().Decode(buffer);
					case 0x1c:
						return new McpeMobEffect().Decode(buffer);
					case 0x1d:
						return new McpeUpdateAttributes().Decode(buffer);
					case 0x1e:
						return new McpeInventoryTransaction().Decode(buffer);
					case 0x1f:
						return new McpeMobEquipment().Decode(buffer);
					case 0x20:
						return new McpeMobArmorEquipment().Decode(buffer);
					case 0x21:
						return new McpeInteract().Decode(buffer);
					case 0x22:
						return new McpeBlockPickRequest().Decode(buffer);
					case 0x23:
						return new McpeEntityPickRequest().Decode(buffer);
					case 0x24:
						return new McpePlayerAction().Decode(buffer);
					case 0x26:
						return new McpeHurtArmor().Decode(buffer);
					case 0x27:
						return new McpeSetEntityData().Decode(buffer);
					case 0x28:
						return new McpeSetEntityMotion().Decode(buffer);
					case 0x29:
						return new McpeSetEntityLink().Decode(buffer);
					case 0x2a:
						return new McpeSetHealth().Decode(buffer);
					case 0x2b:
						return new McpeSetSpawnPosition().Decode(buffer);
					case 0x2c:
						return new McpeAnimate().Decode(buffer);
					case 0x2d:
						return new McpeRespawn().Decode(buffer);
					case 0x2e:
						return new McpeContainerOpen().Decode(buffer);
					case 0x2f:
						return new McpeContainerClose().Decode(buffer);
					case 0x30:
						return new McpePlayerHotbar().Decode(buffer);
					case 0x31:
						return new McpeInventoryContent().Decode(buffer);
					case 0x32:
						return new McpeInventorySlot().Decode(buffer);
					case 0x33:
						return new McpeContainerSetData().Decode(buffer);
					case 0x34:
						return new McpeCraftingData().Decode(buffer);
					case 0x35:
						return new McpeCraftingEvent().Decode(buffer);
					case 0x36:
						return new McpeGuiDataPickItem().Decode(buffer);
					case 0x37:
						return new McpeAdventureSettings().Decode(buffer);
					case 0x38:
						return new McpeBlockEntityData().Decode(buffer);
					case 0x3a:
						return new McpeLevelChunk().Decode(buffer);
					case 0x3b:
						return new McpeSetCommandsEnabled().Decode(buffer);
					case 0x3c:
						return new McpeSetDifficulty().Decode(buffer);
					case 0x3d:
						return new McpeChangeDimension().Decode(buffer);
					case 0x3e:
						return new McpeSetPlayerGameType().Decode(buffer);
					case 0x3f:
						return new McpePlayerList().Decode(buffer);
					case 0x40:
						return new McpeSimpleEvent().Decode(buffer);
					case 0x41:
						return new McpeTelemetryEvent().Decode(buffer);
					case 0x42:
						return new McpeSpawnExperienceOrb().Decode(buffer);
					case 0x43:
						return new McpeClientboundMapItemData().Decode(buffer);
					case 0x44:
						return new McpeMapInfoRequest().Decode(buffer);
					case 0x45:
						return new McpeRequestChunkRadius().Decode(buffer);
					case 0x46:
						return new McpeChunkRadiusUpdate().Decode(buffer);
					case 0x48:
						return new McpeGameRulesChanged().Decode(buffer);
					case 0x49:
						return new McpeCamera().Decode(buffer);
					case 0x4a:
						return new McpeBossEvent().Decode(buffer);
					case 0x4b:
						return new McpeShowCredits().Decode(buffer);
					case 0x4c:
						return new McpeAvailableCommands().Decode(buffer);
					case 0x4d:
						return new McpeCommandRequest().Decode(buffer);
					case 0x4e:
						return new McpeCommandBlockUpdate().Decode(buffer);
					case 0x4f:
						return new McpeCommandOutput().Decode(buffer);
					case 0x50:
						return new McpeUpdateTrade().Decode(buffer);
					case 0x51:
						return new McpeUpdateEquipment().Decode(buffer);
					case 0x52:
						return new McpeResourcePackDataInfo().Decode(buffer);
					case 0x53:
						return new McpeResourcePackChunkData().Decode(buffer);
					case 0x54:
						return new McpeResourcePackChunkRequest().Decode(buffer);
					case 0x55:
						return new McpeTransfer().Decode(buffer);
					case 0x56:
						return new McpePlaySound().Decode(buffer);
					case 0x57:
						return new McpeStopSound().Decode(buffer);
					case 0x58:
						return new McpeSetTitle().Decode(buffer);
					case 0x59:
						return new McpeAddBehaviorTree().Decode(buffer);
					case 0x5a:
						return new McpeStructureBlockUpdate().Decode(buffer);
					case 0x5b:
						return new McpeShowStoreOffer().Decode(buffer);
					case 0x5c:
						return new McpePurchaseReceipt().Decode(buffer);
					case 0x5d:
						return new McpePlayerSkin().Decode(buffer);
					case 0x5e:
						return new McpeSubClientLogin().Decode(buffer);
					case 0x5f:
						return new McpeInitiateWebSocketConnection().Decode(buffer);
					case 0x60:
						return new McpeSetLastHurtBy().Decode(buffer);
					case 0x61:
						return new McpeBookEdit().Decode(buffer);
					case 0x62:
						return new McpeNpcRequest().Decode(buffer);
					case 0x63:
						return new McpePhotoTransfer().Decode(buffer);
					case 0x64:
						return new McpeModalFormRequest().Decode(buffer);
					case 0x65:
						return new McpeModalFormResponse().Decode(buffer);
					case 0x66:
						return new McpeServerSettingsRequest().Decode(buffer);
					case 0x67:
						return new McpeServerSettingsResponse().Decode(buffer);
					case 0x68:
						return new McpeShowProfile().Decode(buffer);
					case 0x69:
						return new McpeSetDefaultGameType().Decode(buffer);
					case 0x6a:
						return new McpeRemoveObjective().Decode(buffer);
					case 0x6b:
						return new McpeSetDisplayObjective().Decode(buffer);
					case 0x6c:
						return new McpeSetScore().Decode(buffer);
					case 0x6d:
						return new McpeLabTable().Decode(buffer);
					case 0x6e:
						return new McpeUpdateBlockSynced().Decode(buffer);
					case 0x6f:
						return new McpeMoveEntityDelta().Decode(buffer);
					case 0x70:
						return new McpeSetScoreboardIdentity().Decode(buffer);
					case 0x71:
						return new McpeSetLocalPlayerAsInitialized().Decode(buffer);
					case 0x72:
						return new McpeUpdateSoftEnum().Decode(buffer);
					case 0x73:
						return new McpeNetworkStackLatency().Decode(buffer);
					case 0x75:
						return new McpeScriptCustomEvent().Decode(buffer);
					case 0x76:
						return new McpeSpawnParticleEffect().Decode(buffer);
					case 0x77:
						return new McpeAvailableEntityIdentifiers().Decode(buffer);
					case 0x79:
						return new McpeNetworkChunkPublisherUpdate().Decode(buffer);
					case 0x7a:
						return new McpeBiomeDefinitionList().Decode(buffer);
					case 0x7b:
						return new McpeLevelSoundEvent().Decode(buffer);
					case 0x7c:
						return new McpeLevelEventGeneric().Decode(buffer);
					case 0x7d:
						return new McpeLecternUpdate().Decode(buffer);
					case 0x7e:
						return new McpeVideoStreamConnect().Decode(buffer);
					case 0x81:
						return new McpeClientCacheStatus().Decode(buffer);
					case 0x82:
						return new McpeOnScreenTextureAnimation().Decode(buffer);
					case 0x83:
						return new McpeMapCreateLockedCopy().Decode(buffer);
					case 0x84:
						return new McpeStructureTemplateDataExportRequest().Decode(buffer);
					case 0x85:
						return new McpeStructureTemplateDataExportResponse().Decode(buffer);
					case 0x86:
						return new McpeUpdateBlockProperties().Decode(buffer);
					case 0x87:
						return new McpeClientCacheBlobStatus().Decode(buffer);
					case 0x88:
						return new McpeClientCacheMissResponse().Decode(buffer);
					case 0x8f:
						return new McpeNetworkSettings().Decode(buffer);
					case 0x90:
						return new McpePlayerAuthInput().Decode(buffer);
					case 0x91:
						return new McpeCreativeContent().Decode(buffer);
					case 0x92:
						return new McpePlayerEnchantOptions().Decode(buffer);
					case 0x93:
						return new McpeItemStackRequest().Decode(buffer);
					case 0x94:
						return new McpeItemStackResponse().Decode(buffer);
					case 0x97:
						return new McpeUpdatePlayerGameType().Decode(buffer);
					case 0x9c:
						return new McpePacketViolationWarning().Decode(buffer);
					case 0xa2:
						return new McpeItemComponent().Decode(buffer);
					case 0xa3:
						return new McpeFilterTextPacket().Decode(buffer);
					case 0xac:
						return new McpeUpdateSubChunkBlocksPacket().Decode(buffer);
					case 0xae:
						return new McpeSubChunkPacket().Decode(buffer);
					case 0xaf:
						return new McpeSubChunkRequestPacket().Decode(buffer);
					case 0xb4:
						return new McpeDimensionData().Decode(buffer);
					case 0xbb:
						return new McpeUpdateAbilities().Decode(buffer);
					case 0xbc:
						return new McpeUpdateAdventureSettings().Decode(buffer);
					case 0xb8:
						return new McpeRequestAbility().Decode(buffer);
					case 0xc1:
						return new McpeRequestNetworkSettings().Decode(buffer);
					case 0x12e:
						return new McpeTrimData().Decode(buffer);
					case 0x12f:
						return new McpeOpenSign().Decode(buffer);
					case 0xe0:
						return new McpeAlexEntityAnimation().Decode(buffer);
					case 0x8a:
						return new McpeEmotePacket().Decode(buffer);
					case 0x98:
						return new McpeEmoteList().Decode(buffer);
					case 0xb9:
						return new McpePermissionRequest().Decode(buffer);
					case 0x133:
						return new McpeSetInventoryOptions().Decode(buffer);
					case 0x138:
						return new McpeServerboundLoadingScreen().Decode(buffer);
					case 0xa0:
						return new McpePlayerFog().Decode(buffer);
					case 0x8D:
						return new McpeAnvilDamage().Decode(buffer);
					case 0xa5:
						return new McpeSyncEntityProperty().Decode(buffer);
					default:
						return new UnknownPacket((byte)id, buffer);
				}

			}
		}
	}
}
