# PVEgame

一个使用 Unity 制作的 2D PVE 游戏练习项目。仓库原描述为“复刻元气骑士”；这是非官方项目，与原作品及其权利方无关。

> 项目仍在开发中，当前内容以基础场景、角色移动和代码结构练习为主，不代表完整游戏。

## 项目内容

- `Assets/Scenes/MainScene.unity`：主菜单场景，包含开始按钮。
- `Assets/Scenes/MiddleScene.unity`：包含 Knight 角色的场景。
- `Assets/Scenes/Room.unity`：房间场景资源。
- `Assets/Scripts/`：游戏循环、Facade、Controller、Mediator、角色工厂和玩家状态机等代码。
- `Assets/Sprites/`、`Assets/Animation/`、`Assets/Tiles/`：精灵、动画和 Tile 资源。
- `Packages/manifest.json`：Unity 包依赖清单。
- `ProjectSettings/`：Unity 项目设置。
- `.vscode/`：VS Code 的 Unity 扩展推荐、调试附加配置和工作区设置。

角色状态机目前包含 Knight 的待机和行走状态；移动读取 Unity 旧版 Input Manager 的 `Horizontal` 和 `Vertical` 轴。

## 最近补充

- 为 `Knight.cs` 添加了初始化顺序、基类初始化、初始待机状态和状态机按类型缓存状态的说明；本次没有改变角色运行逻辑。
- 添加 VS Code Unity 扩展推荐和 Attach to Unity 调试配置。
- 添加 Timeline 项目设置，默认帧率为 60 FPS。

## 环境要求

- Unity **2022.3.62f3c1**
- 使用仓库中的 `Packages/manifest.json` 安装项目依赖

## 打开项目

1. 克隆仓库：

   ```sh
   git clone https://github.com/Pride-0915/PVEGame.git
   ```

2. 在 Unity Hub 中选择 **Add project from disk**，打开克隆得到的 `PVEGame` 文件夹。
3. 使用上述 Unity 版本打开，并等待 Unity 完成首次资源导入。
4. 可在 Project 窗口中打开 `Assets/Scenes/MainScene.unity` 或 `Assets/Scenes/MiddleScene.unity`，在编辑器中进入 Play Mode 验证。

## 当前状态与待检查项

- 主菜单的 `ButtonStart` 当前只输出“游戏开始”日志，还没有实现跳转到游戏场景。
- `ProjectSettings/EditorBuildSettings.asset` 引用了 `Assets/Scenes/SampleScene.unity`，但仓库中没有这个场景。构建前请从 Build Settings 移除该引用，或添加对应场景。
- `MainMenuGameLoop` 使用的 Facade 会创建 `PlayerController`；角色工厂通过名称查找 `Knight`。当前 `MainScene` 中未发现名为 `Knight` 的对象，因此主菜单运行时可能出现空引用；请在 Play Mode 中确认并完善场景初始化逻辑。
- `Room.unity` 当前没有列入 Build Settings。

## 版本控制与资源许可

请保留 Unity 资源旁的 `.meta` 文件，避免资源 GUID 变化导致场景或预制件引用丢失。`Library/`、`Logs/`、`UserSettings/` 等本地生成内容已由 `.gitignore` 排除，Unity 会在打开项目时重新生成。

公开仓库中的代码和资源均可被他人查看或下载。发布或再分发前，请确认美术、字体、音效及其他第三方资源的许可允许这样做。仓库尚未添加 `LICENSE`；在添加许可证前，不应假定他人可以自由复用项目内容。
