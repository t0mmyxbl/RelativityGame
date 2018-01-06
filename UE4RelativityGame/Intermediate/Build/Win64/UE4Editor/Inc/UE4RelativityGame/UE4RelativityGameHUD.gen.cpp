// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "GeneratedCppIncludes.h"
#include "UE4RelativityGameHUD.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeUE4RelativityGameHUD() {}
// Cross Module References
	UE4RELATIVITYGAME_API UClass* Z_Construct_UClass_AUE4RelativityGameHUD_NoRegister();
	UE4RELATIVITYGAME_API UClass* Z_Construct_UClass_AUE4RelativityGameHUD();
	ENGINE_API UClass* Z_Construct_UClass_AHUD();
	UPackage* Z_Construct_UPackage__Script_UE4RelativityGame();
// End Cross Module References
	void AUE4RelativityGameHUD::StaticRegisterNativesAUE4RelativityGameHUD()
	{
	}
	UClass* Z_Construct_UClass_AUE4RelativityGameHUD_NoRegister()
	{
		return AUE4RelativityGameHUD::StaticClass();
	}
	UClass* Z_Construct_UClass_AUE4RelativityGameHUD()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			static UObject* (*const DependentSingletons[])() = {
				(UObject* (*)())Z_Construct_UClass_AHUD,
				(UObject* (*)())Z_Construct_UPackage__Script_UE4RelativityGame,
			};
#if WITH_METADATA
			static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
				{ "HideCategories", "Rendering Actor Input Replication" },
				{ "IncludePath", "UE4RelativityGameHUD.h" },
				{ "ModuleRelativePath", "UE4RelativityGameHUD.h" },
				{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
			};
#endif
			static const FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
				TCppClassTypeTraits<AUE4RelativityGameHUD>::IsAbstract,
			};
			static const UE4CodeGen_Private::FClassParams ClassParams = {
				&AUE4RelativityGameHUD::StaticClass,
				DependentSingletons, ARRAY_COUNT(DependentSingletons),
				0x0080028Cu,
				nullptr, 0,
				nullptr, 0,
				"Game",
				&StaticCppClassTypeInfo,
				nullptr, 0,
				METADATA_PARAMS(Class_MetaDataParams, ARRAY_COUNT(Class_MetaDataParams))
			};
			UE4CodeGen_Private::ConstructUClass(OuterClass, ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(AUE4RelativityGameHUD, 782010628);
	static FCompiledInDefer Z_CompiledInDefer_UClass_AUE4RelativityGameHUD(Z_Construct_UClass_AUE4RelativityGameHUD, &AUE4RelativityGameHUD::StaticClass, TEXT("/Script/UE4RelativityGame"), TEXT("AUE4RelativityGameHUD"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AUE4RelativityGameHUD);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
