using NextPhase.Contracts.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts
{
    public interface IGameCard
    {
        /// <summary>
        /// <para>Gets the Cooldown period that should be waited before being reused by the same <see cref="IPlayer">player</see>.</para>
        /// <para>If the current game card <see cref="Usage">Usage</see> is set to <see cref="UsageType.MultiplewithCooldown"></see>
        /// the value of this property should be used to set a cooldown period.
        /// </para>
        /// </summary>
        TimeSpan? CooldownPeriod { get; }

        /// <summary>
        /// Gets the number of action points to award the player on their current turn.
        /// </summary>
        int? ActionPoints { get; }

        /// <summary>
        /// Gets the friendly display name to be shown to the player
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the friendly display description to be shown to the player, describing the actions of this <see cref="IGameCard">card</see>
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets an action to apply a buff on the current player
        /// </summary>
        Action<IPlayer> Buff { get; }

        /// <summary>
        /// Gets the <see cref="GameCardType">type</see> of this card, used for organising card decks.
        /// </summary>
        GameCardType Type { get; }

        /// <summary>
        /// Gets the <see cref="UsageType">usage</see> of this card, describing whether it can be used multiple times and whether a cool down is required.
        /// </summary>
        UsageType Usage { get; set; }
    }
}
