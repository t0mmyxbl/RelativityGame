// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "ObjectMacros.h"
#include "ScriptMacros.h"

PRAGMA_DISABLE_DEPRECATION_WARNINGS
class UPrimitiveComponent;
class AActor;
struct FVector;
struct FHitResult;
#ifdef UE4RELATIVITYGAME_UE4RelativityGameProjectile_generated_h
#error "UE4RelativityGameProjectile.generated.h already included, missing '#pragma once' in UE4RelativityGameProjectile.h"
#endif
#define UE4RELATIVITYGAME_UE4RelativityGameProjectile_generated_h

#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_RPC_WRAPPERS \
 \
	DECLARE_FUNCTION(execOnHit) \
	{ \
		P_GET_OBJECT(UPrimitiveComponent,Z_Param_HitComp); \
		P_GET_OBJECT(AActor,Z_Param_OtherActor); \
		P_GET_OBJECT(UPrimitiveComponent,Z_Param_OtherComp); \
		P_GET_STRUCT(FVector,Z_Param_NormalImpulse); \
		P_GET_STRUCT_REF(FHitResult,Z_Param_Out_Hit); \
		P_FINISH; \
		P_NATIVE_BEGIN; \
		this->OnHit(Z_Param_HitComp,Z_Param_OtherActor,Z_Param_OtherComp,Z_Param_NormalImpulse,Z_Param_Out_Hit); \
		P_NATIVE_END; \
	}


#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_RPC_WRAPPERS_NO_PURE_DECLS \
 \
	DECLARE_FUNCTION(execOnHit) \
	{ \
		P_GET_OBJECT(UPrimitiveComponent,Z_Param_HitComp); \
		P_GET_OBJECT(AActor,Z_Param_OtherActor); \
		P_GET_OBJECT(UPrimitiveComponent,Z_Param_OtherComp); \
		P_GET_STRUCT(FVector,Z_Param_NormalImpulse); \
		P_GET_STRUCT_REF(FHitResult,Z_Param_Out_Hit); \
		P_FINISH; \
		P_NATIVE_BEGIN; \
		this->OnHit(Z_Param_HitComp,Z_Param_OtherActor,Z_Param_OtherComp,Z_Param_NormalImpulse,Z_Param_Out_Hit); \
		P_NATIVE_END; \
	}


#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_INCLASS_NO_PURE_DECLS \
private: \
	static void StaticRegisterNativesAUE4RelativityGameProjectile(); \
	friend UE4RELATIVITYGAME_API class UClass* Z_Construct_UClass_AUE4RelativityGameProjectile(); \
public: \
	DECLARE_CLASS(AUE4RelativityGameProjectile, AActor, COMPILED_IN_FLAGS(0), 0, TEXT("/Script/UE4RelativityGame"), NO_API) \
	DECLARE_SERIALIZER(AUE4RelativityGameProjectile) \
	enum {IsIntrinsic=COMPILED_IN_INTRINSIC}; \
	static const TCHAR* StaticConfigName() {return TEXT("Game");} \



#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_INCLASS \
private: \
	static void StaticRegisterNativesAUE4RelativityGameProjectile(); \
	friend UE4RELATIVITYGAME_API class UClass* Z_Construct_UClass_AUE4RelativityGameProjectile(); \
public: \
	DECLARE_CLASS(AUE4RelativityGameProjectile, AActor, COMPILED_IN_FLAGS(0), 0, TEXT("/Script/UE4RelativityGame"), NO_API) \
	DECLARE_SERIALIZER(AUE4RelativityGameProjectile) \
	enum {IsIntrinsic=COMPILED_IN_INTRINSIC}; \
	static const TCHAR* StaticConfigName() {return TEXT("Game");} \



#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_STANDARD_CONSTRUCTORS \
	/** Standard constructor, called after all reflected properties have been initialized */ \
	NO_API AUE4RelativityGameProjectile(const FObjectInitializer& ObjectInitializer); \
	DEFINE_DEFAULT_OBJECT_INITIALIZER_CONSTRUCTOR_CALL(AUE4RelativityGameProjectile) \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, AUE4RelativityGameProjectile); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(AUE4RelativityGameProjectile); \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API AUE4RelativityGameProjectile(AUE4RelativityGameProjectile&&); \
	NO_API AUE4RelativityGameProjectile(const AUE4RelativityGameProjectile&); \
public:


#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_ENHANCED_CONSTRUCTORS \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API AUE4RelativityGameProjectile(AUE4RelativityGameProjectile&&); \
	NO_API AUE4RelativityGameProjectile(const AUE4RelativityGameProjectile&); \
public: \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, AUE4RelativityGameProjectile); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(AUE4RelativityGameProjectile); \
	DEFINE_DEFAULT_CONSTRUCTOR_CALL(AUE4RelativityGameProjectile)


#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_PRIVATE_PROPERTY_OFFSET \
	FORCEINLINE static uint32 __PPO__CollisionComp() { return STRUCT_OFFSET(AUE4RelativityGameProjectile, CollisionComp); } \
	FORCEINLINE static uint32 __PPO__ProjectileMovement() { return STRUCT_OFFSET(AUE4RelativityGameProjectile, ProjectileMovement); }


#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_9_PROLOG
#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_GENERATED_BODY_LEGACY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_PRIVATE_PROPERTY_OFFSET \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_RPC_WRAPPERS \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_INCLASS \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_STANDARD_CONSTRUCTORS \
public: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#define UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_GENERATED_BODY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_PRIVATE_PROPERTY_OFFSET \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_RPC_WRAPPERS_NO_PURE_DECLS \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_INCLASS_NO_PURE_DECLS \
	UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h_12_ENHANCED_CONSTRUCTORS \
private: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#undef CURRENT_FILE_ID
#define CURRENT_FILE_ID UE4RelativityGame_Source_UE4RelativityGame_UE4RelativityGameProjectile_h


PRAGMA_ENABLE_DEPRECATION_WARNINGS
