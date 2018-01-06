// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "GeneratedCppIncludes.h"
#include "UE4RelativityGameGameMode.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeUE4RelativityGameGameMode() {}
// Cross Module References
	UE4RELATIVITYGAME_API UClass* Z_Construct_UClass_AUE4RelativityGameGameMode_NoRegister();
	UE4RELATIVITYGAME_API UClass* Z_Construct_UClass_AUE4RelativityGameGameMode();
	ENGINE_API UClass* Z_Construct_UClass_AGameModeBase();
	UPackage* Z_Construct_UPackage__Script_UE4RelativityGame();
// End Cross Module References
	void AUE4RelativityGameGameMode::StaticRegisterNativesAUE4RelativityGameGameMode()
	{
	}
	UClass* Z_Construct_UClass_AUE4RelativityGameGameMode_NoRegister()
	{
		return AUE4RelativityGameGameMode::StaticClass();
	}
	UClass* Z_Construct_UClass_AUE4RelativityGameGameMode()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			static UObject* (*const DependentSingletons[])() = {
				(UObject* (*)())Z_Construct_UClass_AGameModeBase,
				(UObject* (*)())Z_Construct_UPackage__Script_UE4RelativityGame,
			};
#if WITH_METADATA
			static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
				{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
				{ "IncludePath", "UE4RelativityGameGameMode.h" },
				{ "ModuleRelativePath", "UE4RelativityGameGameMode.h" },
				{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
			};
#endif
			static const FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
				TCppClassTypeTraits<AUE4RelativityGameGameMode>::IsAbstract,
			};
			static const UE4CodeGen_Private::FClassParams ClassParams = {
				&AUE4RelativityGameGameMode::StaticClass,
				DependentSingletons, ARRAY_COUNT(DependentSingletons),
				0x00880288u,
				nullptr, 0,
				nullptr, 0,
				nullptr,
				&StaticCppClassTypeInfo,
				nullptr, 0,
				METADATA_PARAMS(Class_MetaDataParams, ARRAY_COUNT(Class_MetaDataParams))
			};
			UE4CodeGen_Private::ConstructUClass(OuterClass, ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(AUE4RelativityGameGameMode, 255397740);
	static FCompiledInDefer Z_CompiledInDefer_UClass_AUE4RelativityGameGameMode(Z_Construct_UClass_AUE4RelativityGameGameMode, &AUE4RelativityGameGameMode::StaticClass, TEXT("/Script/UE4RelativityGame"), TEXT("AUE4RelativityGameGameMode"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AUE4RelativityGameGameMode);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
