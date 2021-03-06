﻿--直接Unityには登録しないスクリプト。いわゆる、ライブラリ化した奴

-- プレイヤーキャラクター定義
PlayerCharacterConfig = {
	{
		IdIndex = CharacterTypeEnum.Mochi,
		PrefabName = "CommonCharacterIcon1",
		Name = "PlayerCharacterObject001",
		Width = 128,
		Height = 128,
		NowHp = 100,
		MaxHp = 100,
		DetailText = "名前はもち\n白くてもちもちしている。かわいい。\n\n攻撃方法は連射速度の弾を撃つ。癖が無く使いやすいはず。",
		SkillConfig = SkillData.new(SkillTable_001),
		SkillDetailText = SkillDetailText001,
		UnlockNeedValue = 0,
		HomePlayerName = "HomeCharacter1",
		BaseParameter = CharacterParameter.new(100, 1, 1, 0),
		--AddParameter = CharacterParameter.new(0, 0, 0, 0),
		GrowType = {
			Hp = 3,
			Attack = 3,
			Deffense = 3,
		},
	},
	{
		IdIndex = CharacterTypeEnum.Tora,
		PrefabName = "CommonCharacterIcon2",
		Name = "PlayerCharacterObject002",
		Width = 128,
		Height = 128,
		NowHp = 50,
		MaxHp = 100,
		DetailText = "名前はとら\nおでこの縦しまが3本。イノシシではない。かわいい。\n\n攻撃方法は連射力と攻撃力が高い直線の弾と、自分を守る弾2種を持つ。",
		SkillConfig = SkillData.new(SkillTable_Tora),
		SkillDetailText = SkillDetailTextTora,
		UnlockNeedValue = 0,
		HomePlayerName = "HomeCharacter2",
		BaseParameter = CharacterParameter.new(100, 2, 2, 0),
		--AddParameter = CharacterParameter.new(0, 0, 0, 0),
		GrowType = {
			Hp = 4,
			Attack = 4,
			Deffense = 1,
		},
	},
	{
		IdIndex = CharacterTypeEnum.Buchi,
		PrefabName = "CommonCharacterIcon3",
		Name = "PlayerCharacterObject003",
		Width = 128,
		Height = 128,
		NowHp = 50,
		MaxHp = 100,
		DetailText = "名前はぶち\nところどころぶち。かわいい。\n\n攻撃方法は、直線に貫通する早い砲台と、それを補う中範囲の攻撃を持つ。",
		SkillConfig = SkillData.new(SkillTable_Buchi),
		SkillDetailText = SkillDetailTextBuchi,
		UnlockNeedValue = 500,
		HomePlayerName = "HomeCharacter3",
		BaseParameter = CharacterParameter.new(100, 3, 3, 0),
		--AddParameter = CharacterParameter.new(0, 0, 0, 0),
		GrowType = {
			Hp = 2,
			Attack = 2,
			Deffense = 5,
		},
	},
	{
		IdIndex = CharacterTypeEnum.Sakura,
		PrefabName = "CommonCharacterIcon4",
		Name = "PlayerCharacterObject004",
		Width = 128,
		Height = 128,
		NowHp = 50,
		MaxHp = 100,
		DetailText = "名前はさくら\nほっぺがチャームポイント。かわいい。\n\n攻撃方法は直線攻撃に加え、自分の左右後方を守る防御弾、短射程の追尾弾を持つ。",
		SkillConfig = SkillData.new(SkillTable_Sakura),
		SkillDetailText = SkillDetailTextSakura,
		--UnlockNeedValue = 500,
		UnlockNeedValue = 0,
		HomePlayerName = "HomeCharacter4",
		BaseParameter = CharacterParameter.new(100, 4, 4, 0),
		--AddParameter = CharacterParameter.new(0, 0, 0, 0),
		GrowType = {
			Hp = 3,
			Attack = 3,
			Deffense = 3,
		},
	},
}


