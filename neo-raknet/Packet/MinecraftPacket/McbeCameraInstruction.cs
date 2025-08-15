using System;
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly
using neo_raknet.Utils.Camera; // Assuming the structs are in this namespace

namespace neo_raknet.Packet.MinecraftPacket
{
    /// <summary>
    /// CameraInstruction 数据包：给自定义相机提供特定的操作指令。
    /// </summary>
    public class McpeCameraInstruction : Packet
    {
        /// <summary>
        /// Set 是一个相机指令，用于将相机设置为指定的预设。
        /// </summary>
        public Optional<CameraAimAssistCategory> Set { get; set; } // 假设 protocol.CameraInstructionSet 对应 CameraAimAssistCategory

        /// <summary>
        /// Clear 可以设置为 true 以清除所有当前的相机指令。
        /// </summary>
        public Optional<bool> Clear { get; set; }

        /// <summary>
        /// Fade 是一个相机指令，用于将屏幕淡化为指定颜色。
        /// </summary>
        public Optional<CameraAimAssistPreset> Fade { get; set; } // 假设 protocol.CameraInstructionFade 对应 CameraAimAssistPreset

        /// <summary>
        /// Target 是一个相机指令，用于瞄准特定的实体。
        /// </summary>
        public Optional<CameraAimAssistItemSettings> Target { get; set; } // 假设 protocol.CameraInstructionTarget 对应 CameraAimAssistItemSettings

        /// <summary>
        /// RemoveTarget 可以设置为 true 以移除当前的瞄准辅助目标。
        /// </summary>
        public Optional<bool> RemoveTarget { get; set; }

        /// <summary>
        /// FieldOfView 是一个相机指令，用于更新相机的视野。
        /// </summary>
        public Optional<CameraAimAssistPriorities> FieldOfView { get; set; } // 假设 protocol.CameraInstructionFieldOfView 对应 CameraAimAssistPriorities

        /// <summary>
        /// 初始化 McpeCameraInstruction 类的新实例。
        /// </summary>
        public McpeCameraInstruction()
        {
            Id = 300; // IDCameraInstruction
            IsMcpe = true;
            // Optional<T> fields are initialized to default (unset) state
        }

        /// <summary>
        /// 编码数据包数据。
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            // --- 直接处理 Optional<T> 的 HasValue 和 Value ---

            // 写入 Set (Optional<CameraAimAssistCategory>)
            Write(Set.HasValue); // 写入 bool
            if (Set.HasValue)
            {
                Write(Set.Value); // 写入 CameraAimAssistCategory
            }

            // 写入 Clear (Optional<bool>)
            Write(Clear.HasValue); // 写入 bool
            if (Clear.HasValue)
            {
                Write(Clear.Value); // 写入 bool
            }

            // 写入 Fade (Optional<CameraAimAssistPreset>)
            Write(Fade.HasValue); // 写入 bool
            if (Fade.HasValue)
            {
                Write(Fade.Value); // 写入 CameraAimAssistPreset
            }

            // 写入 Target (Optional<CameraAimAssistItemSettings>)
            Write(Target.HasValue); // 写入 bool
            if (Target.HasValue)
            {
                Write(Target.Value); // 写入 CameraAimAssistItemSettings
            }

            // 写入 RemoveTarget (Optional<bool>)
            Write(RemoveTarget.HasValue); // 写入 bool
            if (RemoveTarget.HasValue)
            {
                Write(RemoveTarget.Value); // 写入 bool
            }

            // 写入 FieldOfView (Optional<CameraAimAssistPriorities>)
            Write(FieldOfView.HasValue); // 写入 bool
            if (FieldOfView.HasValue)
            {
                Write(FieldOfView.Value); // 写入 CameraAimAssistPriorities
            }
        }

        /// <summary>
        /// 解码数据包数据。
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            // --- 直接处理 Optional<T> 的 HasValue 和 Value ---

            // 读取 Set (Optional<CameraAimAssistCategory>)
            bool hasSet = ReadBool(); // 读取 bool
            if (hasSet)
            {
                Set = new Optional<CameraAimAssistCategory>(ReadCameraAimAssistCategory());
            }

            // 读取 Clear (Optional<bool>)
            bool hasClear = ReadBool(); // 读取 bool
            if (hasClear)
            {
                Clear = new Optional<bool>(ReadBool()); // 读取 bool
            }

            // 读取 Fade (Optional<CameraAimAssistPreset>)
            bool hasFade = ReadBool(); // 读取 bool
            if (hasFade)
            {
                Fade = new Optional<CameraAimAssistPreset>(ReadCameraAimAssistPreset());
            }

            // 读取 Target (Optional<CameraAimAssistItemSettings>)
            bool hasTarget = ReadBool(); // 读取 bool
            if (hasTarget)
            {
                Target = new Optional<CameraAimAssistItemSettings>(ReadCameraAimAssistItemSettings());
            }

            // 读取 RemoveTarget (Optional<bool>)
            bool hasRemoveTarget = ReadBool(); // 读取 bool
            if (hasRemoveTarget)
            {
                RemoveTarget = new Optional<bool>(ReadBool()); // 读取 bool
            }

            // 读取 FieldOfView (Optional<CameraAimAssistPriorities>)
            bool hasFieldOfView = ReadBool(); // 读取 bool
            if (hasFieldOfView)
            {
                FieldOfView = new Optional<CameraAimAssistPriorities>(ReadCameraAimAssistPriorities());
            }
        }

        /// <summary>
        /// 将数据包数据重置为默认值。
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            Set = new Optional<CameraAimAssistCategory>();
            Clear = new Optional<bool>();
            Fade = new Optional<CameraAimAssistPreset>();
            Target = new Optional<CameraAimAssistItemSettings>();
            RemoveTarget = new Optional<bool>();
            FieldOfView = new Optional<CameraAimAssistPriorities>();
        }

        #region Helper Read Methods for Complex Structs

        // --- CameraAimAssistPriority ---
        private CameraAimAssistPriority ReadCameraAimAssistPriority()
        {
            string identifier = ReadString();
            int priority = ReadInt(false); // Assuming little-endian int32
            return new CameraAimAssistPriority(identifier, priority);
        }

        private void Write(CameraAimAssistPriority priority)
        {
            Write(priority.Identifier ?? string.Empty);
            Write(priority.Priority, false); // Assuming little-endian int32
        }

        // --- CameraAimAssistPriorities ---
        private CameraAimAssistPriorities ReadCameraAimAssistPriorities()
        {
            // Read Entities
            uint entitiesCount = ReadUnsignedVarInt();
            CameraAimAssistPriority[] entities = new CameraAimAssistPriority[entitiesCount];
            for (int i = 0; i < entitiesCount; i++)
            {
                entities[i] = ReadCameraAimAssistPriority();
            }

            // Read Blocks
            uint blocksCount = ReadUnsignedVarInt();
            CameraAimAssistPriority[] blocks = new CameraAimAssistPriority[blocksCount];
            for (int i = 0; i < blocksCount; i++)
            {
                blocks[i] = ReadCameraAimAssistPriority();
            }

            // Read EntityDefault (Optional<int>)
            bool hasEntityDefault = ReadBool();
            Optional<int> entityDefault = new Optional<int>();
            if (hasEntityDefault)
            {
                entityDefault = new Optional<int>(ReadInt(false)); // Assuming little-endian int32
            }

            // Read BlockDefault (Optional<int>)
            bool hasBlockDefault = ReadBool();
            Optional<int> blockDefault = new Optional<int>();
            if (hasBlockDefault)
            {
                blockDefault = new Optional<int>(ReadInt(false)); // Assuming little-endian int32
            }

            return new CameraAimAssistPriorities(entities, blocks, entityDefault, blockDefault);
        }

        private void Write(CameraAimAssistPriorities priorities)
        {
            // Write Entities
            WriteUnsignedVarInt((uint)(priorities.Entities?.Length ?? 0));
            if (priorities.Entities != null)
            {
                foreach (var priority in priorities.Entities)
                {
                    Write(priority);
                }
            }

            // Write Blocks
            WriteUnsignedVarInt((uint)(priorities.Blocks?.Length ?? 0));
            if (priorities.Blocks != null)
            {
                foreach (var priority in priorities.Blocks)
                {
                    Write(priority);
                }
            }

            // Write EntityDefault (Optional<int>)
            Write(priorities.EntityDefault.HasValue);
            if (priorities.EntityDefault.HasValue)
            {
                Write(priorities.EntityDefault.Value, false); // Assuming little-endian int32
            }

            // Write BlockDefault (Optional<int>)
            Write(priorities.BlockDefault.HasValue);
            if (priorities.BlockDefault.HasValue)
            {
                Write(priorities.BlockDefault.Value, false); // Assuming little-endian int32
            }
        }

        // --- CameraAimAssistCategory ---
        private CameraAimAssistCategory ReadCameraAimAssistCategory()
        {
            string name = ReadString();
            CameraAimAssistPriorities priorities = ReadCameraAimAssistPriorities();
            return new CameraAimAssistCategory(name, priorities);
        }

        private void Write(CameraAimAssistCategory category)
        {
            Write(category.Name ?? string.Empty);
            Write(category.Priorities);
        }

        // --- CameraAimAssistItemSettings ---
        private CameraAimAssistItemSettings ReadCameraAimAssistItemSettings()
        {
            string item = ReadString();
            string category = ReadString();
            return new CameraAimAssistItemSettings(item, category);
        }

        private void Write(CameraAimAssistItemSettings itemSettings)
        {
            Write(itemSettings.Item ?? string.Empty);
            Write(itemSettings.Category ?? string.Empty);
        }

        // --- CameraAimAssistPreset ---
        private CameraAimAssistPreset ReadCameraAimAssistPreset()
        {
            string identifier = ReadString();

            // Read BlockExclusions
            uint blockExclusionsCount = ReadUnsignedVarInt();
            string[] blockExclusions = new string[blockExclusionsCount];
            for (int i = 0; i < blockExclusionsCount; i++)
            {
                blockExclusions[i] = ReadString();
            }

            // Read LiquidTargets
            uint liquidTargetsCount = ReadUnsignedVarInt();
            string[] liquidTargets = new string[liquidTargetsCount];
            for (int i = 0; i < liquidTargetsCount; i++)
            {
                liquidTargets[i] = ReadString();
            }

            // Read ItemSettings
            uint itemSettingsCount = ReadUnsignedVarInt();
            CameraAimAssistItemSettings[] itemSettings = new CameraAimAssistItemSettings[itemSettingsCount];
            for (int i = 0; i < itemSettingsCount; i++)
            {
                itemSettings[i] = ReadCameraAimAssistItemSettings();
            }

            // Read DefaultItemSettings (Optional<string>)
            bool hasDefaultItemSettings = ReadBool();
            Optional<string> defaultItemSettings = new Optional<string>();
            if (hasDefaultItemSettings)
            {
                defaultItemSettings = new Optional<string>(ReadString());
            }

            // Read HandSettings (Optional<string>)
            bool hasHandSettings = ReadBool();
            Optional<string> handSettings = new Optional<string>();
            if (hasHandSettings)
            {
                handSettings = new Optional<string>(ReadString());
            }

            return new CameraAimAssistPreset(identifier, blockExclusions, liquidTargets, itemSettings, defaultItemSettings, handSettings);
        }

        private void Write(CameraAimAssistPreset preset)
        {
            Write(preset.Identifier ?? string.Empty);

            // Write BlockExclusions
            WriteUnsignedVarInt((uint)(preset.BlockExclusions?.Length ?? 0));
            if (preset.BlockExclusions != null)
            {
                foreach (var exclusion in preset.BlockExclusions)
                {
                    Write(exclusion ?? string.Empty);
                }
            }

            // Write LiquidTargets
            WriteUnsignedVarInt((uint)(preset.LiquidTargets?.Length ?? 0));
            if (preset.LiquidTargets != null)
            {
                foreach (var target in preset.LiquidTargets)
                {
                    Write(target ?? string.Empty);
                }
            }

            // Write ItemSettings
            WriteUnsignedVarInt((uint)(preset.ItemSettings?.Length ?? 0));
            if (preset.ItemSettings != null)
            {
                foreach (var itemSetting in preset.ItemSettings)
                {
                    Write(itemSetting);
                }
            }

            // Write DefaultItemSettings (Optional<string>)
            Write(preset.DefaultItemSettings.HasValue);
            if (preset.DefaultItemSettings.HasValue)
            {
                Write(preset.DefaultItemSettings.Value ?? string.Empty);
            }

            // Write HandSettings (Optional<string>)
            Write(preset.HandSettings.HasValue);
            if (preset.HandSettings.HasValue)
            {
                Write(preset.HandSettings.Value ?? string.Empty);
            }
        }

        #endregion
    }
}