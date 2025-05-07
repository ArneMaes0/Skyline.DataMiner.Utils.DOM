namespace Skyline.DataMiner.Utils.DOM.UnitTesting
{
	using System;
	using System.Collections.Concurrent;

	using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
	using Skyline.DataMiner.Net.Apps.Modules;
	using Skyline.DataMiner.Net.Messages.SLDataGateway;
	using Skyline.DataMiner.Net.Sections;

	internal class DomModule
	{
		public DomModule(string moduleId)
		{
			if (String.IsNullOrWhiteSpace(moduleId))
			{
				throw new ArgumentException($"'{nameof(moduleId)}' cannot be null or whitespace.", nameof(moduleId));
			}

			ModuleId = moduleId;
		}

		public string ModuleId { get; }

		public ModuleSettings Settings { get; set; }

		public ConcurrentDictionary<Guid, DomDefinition> Definitions { get; } = new ConcurrentDictionary<Guid, DomDefinition>();
		public ConcurrentDictionary<Guid, SectionDefinition> SectionDefinitions { get; } = new ConcurrentDictionary<Guid, SectionDefinition>();
		public ConcurrentDictionary<Guid, DomInstance> Instances { get; } = new ConcurrentDictionary<Guid, DomInstance>();
		public ConcurrentDictionary<Guid, DomBehaviorDefinition> BehaviorDefinitions { get; } = new ConcurrentDictionary<Guid, DomBehaviorDefinition>();
		public ConcurrentDictionary<PagingCookie, DomPagingHandler<DomInstance>> PagingHandlers { get; } = new ConcurrentDictionary<PagingCookie, DomPagingHandler<DomInstance>>();

		public void TrySetNameOnDomInstance(DomInstance instance)
		{
			if (instance == null)
			{
				return;
			}

			var nameDefinition = Settings?.DomManagerSettings?.DomInstanceNameDefinition;

			if (nameDefinition != null)
			{
				nameDefinition.SetNameOnDomInstance(instance);
			}
		}
	}
}
