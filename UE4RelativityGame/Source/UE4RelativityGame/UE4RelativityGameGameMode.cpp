// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

#include "UE4RelativityGameGameMode.h"
#include "UE4RelativityGameHUD.h"
#include "UE4RelativityGameCharacter.h"
#include "UObject/ConstructorHelpers.h"

AUE4RelativityGameGameMode::AUE4RelativityGameGameMode()
	: Super()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnClassFinder(TEXT("/Game/FirstPersonCPP/Blueprints/FirstPersonCharacter"));
	DefaultPawnClass = PlayerPawnClassFinder.Class;

	// use our custom HUD class
	HUDClass = AUE4RelativityGameHUD::StaticClass();
}
