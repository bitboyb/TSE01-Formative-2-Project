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
        static const AkUniqueID PLAY_AMBIENCE = 278617630U;
        static const AkUniqueID PLAY_CARSMOKE = 1644548843U;
        static const AkUniqueID PLAY_FOLIAGE = 3773549739U;
        static const AkUniqueID PLAY_FOOTSTEPS_RUNNING = 203814959U;
        static const AkUniqueID PLAY_FOOTSTEPS_WALKING = 1871925003U;
        static const AkUniqueID PLAY_LOOPTEST_2D = 70654913U;
        static const AkUniqueID PLAY_LOOPTEST_3D = 53877366U;
        static const AkUniqueID PLAY_METALCONTAINER = 2378025672U;
        static const AkUniqueID PLAY_ROOSTERCROW = 2387564767U;
        static const AkUniqueID PLAY_SPOTTEST_2D = 3725630887U;
        static const AkUniqueID PLAY_SPOTTEST_3D = 3708853332U;
        static const AkUniqueID PLAY_STREETLIGHT = 828506565U;
        static const AkUniqueID PLAY_TARPCRATE = 3512793250U;
        static const AkUniqueID PLAY_WINDMILL = 1556206602U;
        static const AkUniqueID PLAY_WOLFHOWL = 3582425144U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace INSIDEOUTSIDE
        {
            static const AkUniqueID GROUP = 3929688590U;

            namespace STATE
            {
                static const AkUniqueID INSIDE = 3553349781U;
                static const AkUniqueID OUTSIDE = 438105790U;
            } // namespace STATE
        } // namespace INSIDEOUTSIDE

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
        static const AkUniqueID ATTENUATION = 508408299U;
        static const AkUniqueID DAYNIGHT = 1705516017U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MASTER_SOUNDBANK = 2469504869U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID _2D = 527871411U;
        static const AkUniqueID _3D = 511093792U;
        static const AkUniqueID AMB = 1117531639U;
        static const AkUniqueID DEBUG = 1031089514U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTERAMBIENCE = 2526046175U;
        static const AkUniqueID NOTIFIES = 1229365614U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID SFX = 393239870U;
        static const AkUniqueID SPOTAMBIENCE = 3525696289U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID CONTAINERREVERB = 847970594U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
