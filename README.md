# Fraction (Gooya) Class in C#

A small class that represents a **rational number** as a numerator/denominator pair and
does exact arithmetic on it — no floating point, no loss of precision.

The class is called `Gooya` (گویا), which is the Persian word for *rational number*.

```
FractionClass/
├── FractionClass.sln
├── FractionClass/
│   ├── FractionClass.csproj
│   ├── Gooya.cs        ← the class
│   ├── Program.cs      ← demo
│   └── Properties/AssemblyInfo.cs
└── .gitignore
```

## What it demonstrates

| Concept | Where |
|---|---|
| Encapsulation — fields are `private` so callers cannot corrupt the value | `Gooya.cs` |
| Constructor overloading — no-arg, one-arg, two-arg | `Gooya.cs` |
| Immutability — every operation **returns a new instance** instead of mutating `this` | `Add` / `Sub` / `Mul` / `div` / `Reverse` |
| Automatic reduction to lowest terms (GCD search) | `Simple()` |
| A private helper that only the class itself needs | `Simple()` |
| Guarding against an undefined fraction in the constructor | `if (y == 0) b = 1;` |

The arithmetic is the textbook version:

```
a/b + c/d = (a*d + b*c) / (b*d)
a/b - c/d = (a*d - b*c) / (b*d)
a/b * c/d = (a*c)     / (b*d)
a/b ÷ c/d = (a/b) * (d/c)
```

## Running it

This is a **.NET Framework 4.7.2** console app, so it needs Visual Studio or MSBuild on Windows.

```bash
# from a Visual Studio Developer Command Prompt
msbuild FractionClass.sln /p:Configuration=Release
FractionClass\bin\Release\FractionClass.exe
```

Or just open `FractionClass.sln` and press F5.

## Sample output

The demo multiplies `6/8` by `0/4`, then adds, subtracts and divides the same pair:

```
3/4      <- 6/8 + 0/4
3/4      <- 6/8 - 0/4
0/1      <- 6/8 * 0/4
3/1      <- 6/8 ÷ 0/4
```

## Notes on this version

This is **version 2** of a four-step progression. Compared with version 1 it adds
constructors, makes the operations immutable, and reduces results to lowest terms.

Two things were changed to make the demo run to completion instead of crashing:

1. **`Simple()` divided by zero** whenever the numerator became `0`. The GCD search
   started at `0`, and `a % 0` / `a / 0` threw `DivideByZeroException`. There is now an
   early return for `a == 0`, which yields the canonical form `0/1`.
2. **`Reverse()` produced an invalid fraction.** It assigned the private fields directly,
   bypassing the constructor's `y == 0` guard, so reversing `0/4` gave `4/0` — a division
   by zero waiting to happen. It now goes through the constructor.

The project was also retargeted from .NET Framework **v4.5** to **v4.7.2**, because the
v4.5 targeting pack is no longer available on current machines. No source changes were
needed — only the target framework.

The original Persian comments are preserved as-is.

---

<div dir="rtl">

## کسر (گویا) با زبان C#

این کلاس یک **عدد گویا** (کسر) را به صورت صورت و مخرج نگه می‌دارد و محاسبات را
**دقیق** انجام می‌دهد — بدون استفاده از `float` و بدون خطای گرد کردن.

نام کلاس `Gooya` (گویا) همان واژه فارسی به معنای عدد گویاست.

**مفاهیمی که نشان می‌دهد:**

- **کپسوله‌سازی** — متغیرها `private` هستند تا بیرون از کلاس نشود مقدارشان را خراب کرد
- **سربارگذاری سازنده‌ها** — بدون پارامتر، با یک پارامتر، با دو پارامتر
- **تغییرناپذیری (Immutability)** — هر عملیات به جای تغییر دادن شیء فعلی، **یک شیء جدید برمی‌گرداند**
- **ساده‌سازی کسر** — خودکار به ساده‌ترین حالت (کمترین بزرگ‌ترین مقسوم‌علیه) تبدیل می‌شود
- **جلوگیری از کسر بی‌تعریف** — اگر مخرج صفر باشد، مخرج را ۱ می‌گذارد

**اجرا:** نیازمند Visual Studio یا MSBuild روی ویندوز.

</div>
