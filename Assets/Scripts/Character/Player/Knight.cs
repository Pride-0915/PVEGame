using UnityEngine;
// 这个类是骑士角色的实现，继承自IPlayer接口
public class Knight : IPlayer
{
    // 构造函数，构造骑士的时候需要传入一个Unity游戏对象(Object),base(obj)是把这个对象传给父类IPlayer构造函数
    // 这个构造函数的结构体为空({ }),构造部分都在OnInit里面
    public Knight(GameObject obj) : base(obj) { }
    // 这里重写了父类的OnInit函数,protected(只有当前类及其子类可以调用),override(覆盖父类的虚方法)
    protected override void OnInit()
    {
        // base调用父类构造方法,即IPlayer.OnInit(),而IPlayer里面也有base,最终会继续调用ICharacter
        base.OnInit();
        // 初始化了骑士的状态机，并设置初始状态为Idle状态
        m_StateMachine.SetState<KnightIdleState>();
    }
}

// 依次执行:
// Knight构造函数
//  -> IPlayer构造函数
//      -> ICharacter构造函数
//          -> 保存 GameObject

// 父类中的方法由子类向上覆盖:
// ICharacter.OnInit()
// IPlayer.OnInit()
// Knight.OnInit()

// 在 C# 中,base 关键字用于在派生类(子类)中访问基类(父类)的成员(包括方法、属性、字段、构造函数等)
// 如果有多层继承,直指向最近的父类,如果父类中还有base同理

// 初始化顺序是:
// 1. ICharacter.OnInit()
// 2. IPlayer.OnInit()
// 3. Knight.OnInit()

// 所以父类初始化完成后:
// 已经创建玩家状态机;
// 已经找到子物体 Sprite;
// 已经取得该物体上的 Animator.

// 这里使用泛型：(自动判断数据类型,由编译器在编译阶段完成的)
// 不需要传入已经创建好的对象;
// 只需要传入状态类的类型;
// 状态机会在字典中查找或创建该状态;
// 状态机内部使用反射创建:

// 反射创建对象:
// 程序在运行时,通过代码看清并操作自己的数据类型
// (不清楚数据类型,但是知道名字,动态创建一个这个类型的实例)
// 反射虽然灵活,但是性能开销大(慢)
// 频繁new对象会产生大量短命的垃圾,到达一定阈值时Unity会触发GC清理(卡顿)

// 字典缓存与复用:(解决反射的性能问题)
// 字典是一种键值对(Key-Value)集合 (哈希算法)
// 例:
// Key（钥匙）：状态的类型（Type），比如 typeof(KnightIdleState)
// Value（值）：该状态的对象实例（StateBase）
// Dictionary<Type, StateBase> m_StateCache = new Dictionary<Type, StateBase>();
// 状态机类在构造的时候,只new了一个空字典
// 每一次触发状态机的时候(调用SetState时),开始查字典构造实例
// 如果字典没有就new一个,如果字典有就复用 (状态的生命周期和字典的生命周期一致)