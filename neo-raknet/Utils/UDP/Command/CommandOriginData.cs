using neo_protocol.Utils;

namespace neo_protocol.Utils.UDP.Command
{
	public enum CommandOriginType
	{
		Player = 0,
		Block = 1,
		MinecartBlock = 2,
		DevConsole = 3,
		Test = 4,
		AutomationPlayer = 5,
		ClientAutomation = 6,
		DedicatedServer = 7,
		Entity = 8,
		Virtual = 9,
		GameArgument = 10,
		EntityServer = 11
	}

	public class CommandOriginData
	{
		public CommandOriginType Type { get; set; }
		public UUID UUID { get; set; }
		public string RequestId { get; set; }
		public long EntityUniqueId { get; set; }

		public CommandOriginData(CommandOriginType type, UUID uuid, string requestId, long entityUniqueId)
		{
			Type = type;
			UUID = uuid;
			RequestId = requestId;
			EntityUniqueId = entityUniqueId;
		}
	}
}
