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
                    case 1:     // IDLogin
                        return new McpeLogin().Decode(buffer);
                    case 2:     // IDPlayStatus
                        return new McpePlayStatus().Decode(buffer);
                    case 3:     // IDServerToClientHandshake
                        return new McpeServerToClientHandshake().Decode(buffer);
                    case 4:     // IDClientToServerHandshake
                        return new McpeClientToServerHandshake().Decode(buffer);
                    case 5:     // IDDisconnect
                        return new McpeDisconnect().Decode(buffer);
                    case 6:     // IDResourcePacksInfo
                        return new McpeResourcePacksInfo().Decode(buffer);
                    case 7:     // IDResourcePackStack
                        return new McpeResourcePackStack().Decode(buffer);
                    case 8:     // IDResourcePackClientResponse
                        return new McpeResourcePackClientResponse().Decode(buffer);
                    case 9:     // IDText
                        return new McpeText().Decode(buffer);
                    case 10:    // IDSetTime
                        return new McpeSetTime().Decode(buffer);
                    case 11:    // IDStartGame
                        return new McpeStartGame().Decode(buffer);
                    case 12:    // IDAddPlayer
                        return new McpeAddPlayer().Decode(buffer);
                    case 13:    // IDAddActor
                        return new McpeAddEntity().Decode(buffer);
                    case 14:    // IDRemoveActor
                        return new McpeRemoveEntity().Decode(buffer);
                    case 15:    // IDAddItemActor
                        return new McpeAddItemEntity().Decode(buffer);
                    case 16:    // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 17:    // IDTakeItemActor
                        return new McpeTakeItemEntity().Decode(buffer);
                    case 18:    // IDMoveActorAbsolute
                        return new McpeMoveEntity().Decode(buffer);
                    case 19:    // IDMovePlayer
                        return new McpeMovePlayer().Decode(buffer);
                    case 20:    // 0x14
                        return new McpeRiderJump().Decode(buffer);
                    case 21:    // IDUpdateBlock
                        return new McpeUpdateBlock().Decode(buffer);
                    case 22:    // IDAddPainting
                        return new McpeAddPainting().Decode(buffer);
                    case 23:    // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 24:    // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 25:    // IDLevelEvent
                        return new McpeLevelEvent().Decode(buffer);
                    case 26:    // IDBlockEvent
                        return new McpeBlockEvent().Decode(buffer);
                    case 27:    // IDActorEvent
                        return new McpeEntityEvent().Decode(buffer);
                    case 28:    // IDMobEffect
                        return new McpeMobEffect().Decode(buffer);
                    case 29:    // IDUpdateAttributes
                        return new McpeUpdateAttributes().Decode(buffer);
                    case 30:    // IDInventoryTransaction
                        return new McpeInventoryTransaction().Decode(buffer);
                    case 31:    // IDMobEquipment
                        return new McpeMobEquipment().Decode(buffer);
                    case 32:    // IDMobArmourEquipment
                        return new McpeMobArmorEquipment().Decode(buffer);
                    case 33:    // IDInteract
                        return new McpeInteract().Decode(buffer);
                    case 34:    // IDBlockPickRequest
                        return new McpeBlockPickRequest().Decode(buffer);
                    case 35:    // IDActorPickRequest
                        return new McpeEntityPickRequest().Decode(buffer);
                    case 36:    // IDPlayerAction
                        return new McpePlayerAction().Decode(buffer);
                    case 37:    // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 38:    // IDHurtArmour
                        return new McpeHurtArmor().Decode(buffer);
                    case 39:    // IDSetActorData
                        return new McpeSetEntityData().Decode(buffer);
                    case 40:    // IDSetActorMotion
                        return new McpeSetEntityMotion().Decode(buffer);
                    case 41:    // IDSetActorLink
                        return new McpeSetEntityLink().Decode(buffer);
                    case 42:    // IDSetHealth
                        return new McpeSetHealth().Decode(buffer);
                    case 43:    // IDSetSpawnPosition
                        return new McpeSetSpawnPosition().Decode(buffer);
                    case 44:    // IDAnimate
                        return new McpeAnimate().Decode(buffer);
                    case 45:    // IDRespawn
                        return new McpeRespawn().Decode(buffer);
                    case 46:    // IDContainerOpen
                        return new McpeContainerOpen().Decode(buffer);
                    case 47:    // IDContainerClose
                        return new McpeContainerClose().Decode(buffer);
                    case 48:    // IDPlayerHotBar
                        return new McpePlayerHotbar().Decode(buffer);
                    case 49:    // IDInventoryContent
                        return new McpeInventoryContent().Decode(buffer);
                    case 50:    // IDInventorySlot
                        return new McpeInventorySlot().Decode(buffer);
                    case 51:    // IDContainerSetData
                        return new McpeContainerSetData().Decode(buffer);
                    case 52:    // IDCraftingData
                        return new McpeCraftingData().Decode(buffer);
                    case 53:    // 0x35
                        return new McpeCraftingEvent().Decode(buffer);
                    case 54:    // IDGUIDataPickItem
                        return new McpeGuiDataPickItem().Decode(buffer);
                    case 55:    // IDAdventureSettings
                        return new McpeAdventureSettings().Decode(buffer);
                    case 56:    // IDBlockActorData
                        return new McpeBlockEntityData().Decode(buffer);
                    case 57:    // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 58:    // IDLevelChunk
                        return new McpeLevelChunk().Decode(buffer);
                    case 59:    // IDSetCommandsEnabled
                        return new McpeSetCommandsEnabled().Decode(buffer);
                    case 60:    // IDSetDifficulty
                        return new McpeSetDifficulty().Decode(buffer);
                    case 61:    // IDChangeDimension
                        return new McpeChangeDimension().Decode(buffer);
                    case 62:    // IDSetPlayerGameType
                        return new McpeSetPlayerGameType().Decode(buffer);
                    case 63:    // IDPlayerList
                        return new McpePlayerList().Decode(buffer);
                    case 64:    // IDSimpleEvent
                        return new McpeSimpleEvent().Decode(buffer);
                    case 65:    // IDEvent (TelemetryEvent)
                        return new McpeTelemetryEvent().Decode(buffer);
                    case 66:    // IDSpawnExperienceOrb
                        return new McpeSpawnExperienceOrb().Decode(buffer);
                    case 67:    // IDClientBoundMapItemData
                        return new McpeClientboundMapItemData().Decode(buffer);
                    case 68:    // IDMapInfoRequest
                        return new McpeMapInfoRequest().Decode(buffer);
                    case 69:    // IDRequestChunkRadius
                        return new McpeRequestChunkRadius().Decode(buffer);
                    case 70:    // IDChunkRadiusUpdated
                        return new McpeChunkRadiusUpdate().Decode(buffer);
                    case 71:    // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 72:    // IDGameRulesChanged
                        return new McpeGameRulesChanged().Decode(buffer);
                    case 73:    // IDCamera
                        return new McpeCamera().Decode(buffer);
                    case 74:    // IDBossEvent
                        return new McpeBossEvent().Decode(buffer);
                    case 75:    // IDShowCredits
                        return new McpeShowCredits().Decode(buffer);
                    case 76:    // IDAvailableCommands
                        return new McpeAvailableCommands().Decode(buffer);
                    case 77:    // IDCommandRequest
                        return new McpeCommandRequest().Decode(buffer);
                    case 78:    // IDCommandBlockUpdate
                        return new McpeCommandBlockUpdate().Decode(buffer);
                    case 79:    // IDCommandOutput
                        return new McpeCommandOutput().Decode(buffer);
                    case 80:    // IDUpdateTrade
                        return new McpeUpdateTrade().Decode(buffer);
                    case 81:    // IDUpdateEquip
                        return new McpeUpdateEquipment().Decode(buffer);
                    case 82:    // IDResourcePackDataInfo
                        return new McpeResourcePackDataInfo().Decode(buffer);
                    case 83:    // IDResourcePackChunkData
                        return new McpeResourcePackChunkData().Decode(buffer);
                    case 84:    // IDResourcePackChunkRequest
                        return new McpeResourcePackChunkRequest().Decode(buffer);
                    case 85:    // IDTransfer
                        return new McpeTransfer().Decode(buffer);
                    case 86:    // IDPlaySound
                        return new McpePlaySound().Decode(buffer);
                    case 87:    // IDStopSound
                        return new McpeStopSound().Decode(buffer);
                    case 88:    // IDSetTitle
                        return new McpeSetTitle().Decode(buffer);
                    case 89:    // IDAddBehaviourTree
                        return new McpeAddBehaviorTree().Decode(buffer);
                    case 90:    // IDStructureBlockUpdate
                        return new McpeStructureBlockUpdate().Decode(buffer);
                    case 91:    // IDShowStoreOffer
                        return new McpeShowStoreOffer().Decode(buffer);
                    case 92:    // IDPurchaseReceipt
                        return new McpePurchaseReceipt().Decode(buffer);
                    case 93:    // IDPlayerSkin
                        return new McpePlayerSkin().Decode(buffer);
                    case 94:    // IDSubClientLogin
                        return new McpeSubClientLogin().Decode(buffer);
                    case 95:    // IDAutomationClientConnect
                        return new McpeInitiateWebSocketConnection().Decode(buffer);
                    case 96:    // IDSetLastHurtBy
                        return new McpeSetLastHurtBy().Decode(buffer);
                    case 97:    // IDBookEdit
                        return new McpeBookEdit().Decode(buffer);
                    case 98:    // IDNPCRequest
                        return new McpeNpcRequest().Decode(buffer);
                    case 99:    // IDPhotoTransfer
                        return new McpePhotoTransfer().Decode(buffer);
                    case 100:   // IDModalFormRequest
                        return new McpeModalFormRequest().Decode(buffer);
                    case 101:   // IDModalFormResponse
                        return new McpeModalFormResponse().Decode(buffer);
                    case 102:   // IDServerSettingsRequest
                        return new McpeServerSettingsRequest().Decode(buffer);
                    case 103:   // IDServerSettingsResponse
                        return new McpeServerSettingsResponse().Decode(buffer);
                    case 104:   // IDShowProfile
                        return new McpeShowProfile().Decode(buffer);
                    case 105:   // IDSetDefaultGameType
                        return new McpeSetDefaultGameType().Decode(buffer);
                    case 106:   // IDRemoveObjective
                        return new McpeRemoveObjective().Decode(buffer);
                    case 107:   // IDSetDisplayObjective
                        return new McpeSetDisplayObjective().Decode(buffer);
                    case 108:   // IDSetScore
                        return new McpeSetScore().Decode(buffer);
                    case 109:   // IDLabTable
                        return new McpeLabTable().Decode(buffer);
                    case 110:   // IDUpdateBlockSynced
                        return new McpeUpdateBlockSynced().Decode(buffer);
                    case 111:   // IDMoveActorDelta
                        return new McpeMoveEntityDelta().Decode(buffer);
                    case 112:   // IDSetScoreboardIdentity
                        return new McpeSetScoreboardIdentity().Decode(buffer);
                    case 113:   // IDSetLocalPlayerAsInitialised
                        return new McpeSetLocalPlayerAsInitialized().Decode(buffer);
                    case 114:   // IDUpdateSoftEnum
                        return new McpeUpdateSoftEnum().Decode(buffer);
                    case 115:   // IDNetworkStackLatency
                        return new McpeNetworkStackLatency().Decode(buffer);
                    case 116:   // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 117:   // IDScriptCustomEvent
                        return new McpeScriptCustomEvent().Decode(buffer);
                    case 118:   // IDSpawnParticleEffect
                        return new McpeSpawnParticleEffect().Decode(buffer);
                    case 119:   // IDAvailableActorIdentifiers
                        return new McpeAvailableEntityIdentifiers().Decode(buffer);
                    case 120:   // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 121:   // IDNetworkChunkPublisherUpdate
                        return new McpeNetworkChunkPublisherUpdate().Decode(buffer);
                    case 122:   // IDBiomeDefinitionList
                        return new McpeBiomeDefinitionList().Decode(buffer);
                    case 123:   // IDLevelSoundEvent
                        return new McpeLevelSoundEvent().Decode(buffer);
                    case 124:   // IDLevelEventGeneric
                        return new McpeLevelEventGeneric().Decode(buffer);
                    case 125:   // IDLecternUpdate
                        return new McpeLecternUpdate().Decode(buffer);
                    case 126:   // 0x7e
                        return new McpeVideoStreamConnect().Decode(buffer);
                    case 127:   // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 128:   // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 129:   // IDClientCacheStatus
                        return new McpeClientCacheStatus().Decode(buffer);
                    case 130:   // IDOnScreenTextureAnimation
                        return new McpeOnScreenTextureAnimation().Decode(buffer);
                    case 131:   // IDMapCreateLockedCopy
                        return new McpeMapCreateLockedCopy().Decode(buffer);
                    case 132:   // IDStructureTemplateDataRequest
                        return new McpeStructureTemplateDataExportRequest().Decode(buffer);
                    case 133:   // IDStructureTemplateDataResponse
                        return new McpeStructureTemplateDataExportResponse().Decode(buffer);
                    case 134:   // IDUpdateBlockProperties
                        return new McpeUpdateBlockProperties().Decode(buffer);
                    case 135:   // IDClientCacheBlobStatus
                        return new McpeClientCacheBlobStatus().Decode(buffer);
                    case 136:   // IDClientCacheMissResponse
                        return new McpeClientCacheMissResponse().Decode(buffer);
                    case 137:   // IDEducationSettings
                        return new McpeEducationSettings().Decode(buffer);
                        break; // EducationSettings
                    case 138:   // IDEmote
                        return new McpeEmotePacket().Decode(buffer);
                    case 139:   // IDMultiPlayerSettings
                        return new McpeMultiPlayerSettings().Decode(buffer);
                        break; // MultiPlayerSettings
                    case 140:   // IDSettingsCommand
                        return new McpeSettingsCommand().Decode(buffer);
                        break; // SettingsCommand
                    case 141:   // IDCompletedUsingItem
                        return new McpeCompletedUsingItem().Decode(buffer);
                        break; // CompletedUsingItem
                    case 142:   // IDNetworkSettings
                        return new McpeNetworkSettings().Decode(buffer);
                    case 143:   // IDPlayerAuthInput
                        return new McpePlayerAuthInput().Decode(buffer);
                    case 144:   // IDCreativeContent
                        return new McpeCreativeContent().Decode(buffer);
                    case 145:   // IDPlayerEnchantOptions
                        return new McpePlayerEnchantOptions().Decode(buffer);
                    case 146:   // IDItemStackRequest
                        return new McpeItemStackRequest().Decode(buffer);
                    case 147:   // IDItemStackResponse
                        return new McpeItemStackResponse().Decode(buffer);
                    case 148:   // IDPlayerArmourDamage
                        return new McbePlayerArmourDamage().Decode(buffer);
                    case 149:   // IDCodeBuilder
                        break; // CodeBuilder
                    case 150:   // IDUpdatePlayerGameType
                        return new McpeUpdatePlayerGameType().Decode(buffer);
                    case 151:   // IDEmoteList
                        return new McpeEmoteList().Decode(buffer);
                    case 152:   // IDPositionTrackingDBServerBroadcast
                        break; // PositionTrackingDBServerBroadcast
                    case 153:   // IDPositionTrackingDBClientRequest
                        break; // PositionTrackingDBClientRequest
                    case 154:   // IDDebugInfo
                        break; // DebugInfo
                    case 155:   // IDPacketViolationWarning
                        return new McpePacketViolationWarning().Decode(buffer);
                    case 156:   // IDMotionPredictionHints
                        break; // MotionPredictionHints
                    case 157:   // IDAnimateEntity
                        break; // AnimateEntity
                    case 158:   // IDCameraShake
                        break; // CameraShake
                    case 159:   // IDPlayerFog
                        return new McpePlayerFog().Decode(buffer);
                    case 160:   // IDCorrectPlayerMovePrediction
                        break; // CorrectPlayerMovePrediction
                    case 161:   // IDItemRegistry
                        break; // ItemRegistry
                    case 162:   // IDFilterText
                        return new McpeFilterTextPacket().Decode(buffer);
                    case 163:   // IDClientBoundDebugRenderer
                        break; // ClientBoundDebugRenderer
                    case 164:   // IDSyncActorProperty
                        return new McpeSyncEntityProperty().Decode(buffer);
                    case 165:   // IDAddVolumeEntity
                        break; // AddVolumeEntity
                    case 166:   // IDRemoveVolumeEntity
                        break; // RemoveVolumeEntity
                    case 167:   // IDSimulationType
                        break; // SimulationType
                    case 168:   // IDNPCDialogue
                        break; // NPCDialogue
                    case 169:   // IDEducationResourceURI
                        break; // EducationResourceURI
                    case 170:   // IDCreatePhoto
                        break; // CreatePhoto
                    case 171:   // IDUpdateSubChunkBlocks
                        return new McpeUpdateSubChunkBlocksPacket().Decode(buffer);
                    case 172:   // IDPhotoInfoRequest
                        break; // PhotoInfoRequest
                    case 173:   // IDSubChunk
                        return new McpeSubChunkPacket().Decode(buffer);
                    case 174:   // IDSubChunkRequest
                        return new McpeSubChunkRequestPacket().Decode(buffer);
                    case 175:   // IDClientStartItemCooldown
                        break; // ClientStartItemCooldown
                    case 176:   // IDScriptMessage
                        break; // ScriptMessage
                    case 177:   // IDCodeBuilderSource
                        break; // CodeBuilderSource
                    case 178:   // IDTickingAreasLoadStatus
                        break; // TickingAreasLoadStatus
                    case 179:   // IDDimensionData
                        return new McpeDimensionData().Decode(buffer);
                    case 180:   // IDAgentAction
                        break; // AgentAction
                    case 181:   // IDChangeMobProperty
                        break; // ChangeMobProperty
                    case 182:   // IDLessonProgress
                        break; // LessonProgress
                    case 183:   // IDRequestAbility
                        return new McpeRequestAbility().Decode(buffer);
                    case 184:   // IDRequestPermissions
                        return new McpePermissionRequest().Decode(buffer);
                    case 185:   // IDToastRequest
                        break; // ToastRequest
                    case 186:   // IDUpdateAbilities
                        return new McpeUpdateAbilities().Decode(buffer);
                    case 187:   // IDUpdateAdventureSettings
                        return new McpeUpdateAdventureSettings().Decode(buffer);
                    case 188:   // IDDeathInfo
                        break; // DeathInfo
                    case 189:   // IDEditorNetwork
                        break; // EditorNetwork
                    case 190:   // IDFeatureRegistry
                        break; // FeatureRegistry
                    case 191:   // IDServerStats
                        break; // ServerStats
                    case 192:   // IDRequestNetworkSettings
                        return new McpeRequestNetworkSettings().Decode(buffer);
                    case 193:   // IDGameTestRequest
                        break; // GameTestRequest
                    case 194:   // IDGameTestResults
                        break; // GameTestResults
                    case 195:   // IDTickingAreasLoadStatus (duplicate)
                        break; // TickingAreasLoadStatus
                    case 196:   // IDUpdateClientInputLocks
                        break; // UpdateClientInputLocks
                    case 197:   // IDClientCheatAbility
                        break; // ClientCheatAbility
                    case 198:   // IDCameraPresets
                        break; // CameraPresets
                    case 199:   // IDUnlockedRecipes
                        break; // UnlockedRecipes
                    case 200:   // IDCameraInstruction
                        break; // CameraInstruction
                    case 201:   // _ (skipped after CameraInstruction)
                        break; // Placeholder (Go: _)
                    case 302:   // IDTrimData
                        return new McpeTrimData().Decode(buffer);
                    case 303:   // IDOpenSign
                        return new McpeOpenSign().Decode(buffer);
                    case 304:   // IDAgentAnimation
                        return new McpeAlexEntityAnimation().Decode(buffer);
                    case 305:   // IDRefreshEntitlements
                        break; // RefreshEntitlements
                    case 306:   // IDPlayerToggleCrafterSlotRequest
                        break; // PlayerToggleCrafterSlotRequest
                    case 307:   // IDSetPlayerInventoryOptions
                        return new McpeSetInventoryOptions().Decode(buffer);
                    case 308:   // IDSetHud
                        break; // SetHud
                    case 309:   // IDAwardAchievement
                        break; // AwardAchievement
                    case 310:   // IDClientBoundCloseForm
                        break; // ClientBoundCloseForm
                    case 311:   // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 312:   // IDServerBoundLoadingScreen
                        return new McpeServerboundLoadingScreen().Decode(buffer);
                    case 313:   // IDJigsawStructureData
                        break; // JigsawStructureData
                    case 314:   // IDCurrentStructureFeature
                        break; // CurrentStructureFeature
                    case 315:   // IDServerBoundDiagnostics
                        break; // ServerBoundDiagnostics
                    case 316:   // IDCameraAimAssist
                        break; // CameraAimAssist
                    case 317:   // IDContainerRegistryCleanup
                        break; // ContainerRegistryCleanup
                    case 318:   // IDMovementEffect
                        break; // MovementEffect
                    case 319:   // _ (skipped)
                        break; // Placeholder (Go: _)
                    case 320:   // IDCameraAimAssistPresets
                        break; // CameraAimAssistPresets
                    case 321:   // IDClientCameraAimAssist
                        break; // ClientCameraAimAssist
                    case 322:   // IDClientMovementPredictionSync
                        break; // ClientMovementPredictionSync
                    case 323:   // IDUpdateClientOptions
                        break; // UpdateClientOptions
                    case 324:   // IDPlayerVideoCapture
                        break; // PlayerVideoCapture
                    case 325:   // IDPlayerUpdateEntityOverrides
                        break; // PlayerUpdateEntityOverrides
                    case 326:   // IDPlayerLocation
                        break; // PlayerLocation
                    case 327:   // IDClientBoundControlSchemeSet
                        break; // ClientBoundControlSchemeSet
                    case 328:   // IDServerScriptDebugDrawer
                        break; // ServerScriptDebugDrawer

                    default:
                        return new UnknownPacket((byte)id, buffer);
                }

                return null;

            }
        }
    }
}
