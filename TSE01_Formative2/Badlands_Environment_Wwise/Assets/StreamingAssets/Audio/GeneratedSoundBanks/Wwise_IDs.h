/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_FOOTSTEPS_RUNNING = 203814959U;
        static const AkUniqueID PLAY_FOOTSTEPS_WALKING = 1871925003U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace LOCATION
        {
            static const AkUniqueID GROUP = 1176052424U;

            namespace STATE
            {
                static const AkUniqueID INTOWN = 3700428288U;
                static const AkUniqueID OUTOFTOWN = 368685200U;
            } // namespace STATE
        } // namespace LOCATION

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEP_SURFACES
        {
            static const AkUniqueID GROUP = 1265478494U;

            namespace SWITCH
            {
                static const AkUniqueID CONCRETE = 841620460U;
                static const AkUniqueID METAL = 2473969246U;
                static const AkUniqueID ROCK = 2144363834U;
                static const AkUniqueID SAND = 803837735U;
                static const AkUniqueID WOOD = 2058049674U;
            } // namespace SWITCH
        } // namespace FOOTSTEP_SURFACES

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID DAYNIGHT = 1705516017U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MASTER_SOUNDBANK = 2469504869U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
