using AutoMapper;
using TicTacToeAPI.DataTransferObjects;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Profiles
{
    /** <summary>
        This class represents Profile Object for the Player object model
        as it maps to the Game Data Transfer Object and handles the 
        mapping between the two.
    </summary> **/
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDTO>();
        }
    }
}