using MEC;
using Neuron.Core.Events;
using Neuron.Core.Meta;
using Neuron.Core.Plugins;
using PlayerRoles;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Events;
using Synapse3.SynapseModule.Player;

namespace Scp939Rework
{
    [Plugin(
        Name = "Scp939Rework",
        Description = "SCP-939 Rework! Chances for 096 to be replaced by 939 and 939 gains health when attacking people!",
        Version = "1.0.0",
        Author = "rootinforya"
    )]
    public class Scp939ReworkPlugin : ReloadablePlugin<Scp939ReworkConfig, Scp939ReworkTranslations>
    {
        public override void EnablePlugin()
        {
            Logger.Info(Translation.Get().EnableMessage);
        }
    }

    [Automatic]
    public class EventHandler : Listener
    {
        private readonly Scp939ReworkPlugin _plugin;
        private readonly PlayerService _player;
        public EventHandler(Scp939ReworkPlugin plugin, PlayerService playerService)
        {
            _plugin = plugin;
            _player = playerService;
        }

        [EventHandler]
        public void On939Damage(Scp939AttackEvent ev)
        {
            if(ev.Allow)
            {
                ev.Scp.Heal(ev.Damage * _plugin.Config.DamageMultiplier);
            }
        }

        [EventHandler]
        public void OnRoundStart(RoundStartEvent ev)
        {
            Timing.CallDelayed(0.1f, () => 
            {
                foreach (var player in _player.Players)
                {
                    if(player.RoleID == (uint)RoleTypeId.Scp096 
                        && UnityEngine.Random.Range(0, 100) <= _plugin.Config.Scp939Replace096Chance)
                    {
                        player.RoleID = (uint)RoleTypeId.Scp939;
                    }
                }
            });
        }
    }
}

