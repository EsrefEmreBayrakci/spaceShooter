## Space Shooter

Modern 2D space shooter game built with Unity (URP) and the new Input System.

---

### English

#### Features
- Arcade-style space shooter gameplay
- Keyboard, gamepad and on-screen joystick (mobile) support
- Unity Input System integration
- URP visuals and post-processing

#### Requirements
- Unity 2022 LTS or newer (project generated with 2022.x)
- Unity Universal Render Pipeline (URP)
- Unity Input System package

#### Getting Started
1. Open Unity Hub.
2. Click "Open" and select the `spaceShooter` folder.
3. After the project loads, open the main scene in `Assets/Scenes`.

#### Controls (Desktop)
- WASD or Arrow Keys: Move
- Space or Left Mouse: Fire
- Escape: Pause/Menu (if available)

Gamepad (if connected):
- Left Stick / D-Pad: Move
- South Button (A / Cross): Fire
- Start/Menu: Pause

Mobile:
- On-screen joystick from `Assets/Joystick Pack` handles movement
- On-screen fire button (if present) handles shooting

#### Build
- Android: File → Build Settings → Android → Switch Platform → Build. APKs in `oyun/` are example outputs.
- Desktop: File → Build Settings → PC, Mac & Linux Standalone → Build.

#### Project Structure (key folders)
- `Assets/Scripts`: Core gameplay scripts
- `Assets/Prefabs`: Reusable game objects
- `Assets/Sprites`: Visual assets
- `Assets/Sounds`: Audio assets
- `Assets/Scenes`: Game scenes
- `Assets/Joystick Pack`: Mobile joystick assets

#### Notes
- Input maps are defined in `Assets/InputSystem_Actions.inputactions` and generated to `Assets/InputSystem_Actions.cs`.
- If inputs appear unresponsive, ensure the Input System is enabled (Edit → Project Settings → Player → Active Input Handling: Input System Package).

#### License & Credits
- Joystick Pack by Fenerax Studios (see their license)


---

### Türkçe

#### Özellikler
- Arcade tarzı 2D uzay savaş oyunu
- Klavye, gamepad ve ekrandaki joystick (mobil) desteği
- Unity Input System entegrasyonu
- URP görüntüleme ve post-processing

#### Gereksinimler
- Unity 2022 LTS veya üzeri (proje 2022.x ile oluşturuldu)
- Unity Universal Render Pipeline (URP)
- Unity Input System paketi

#### Başlangıç
1. Unity Hub'ı açın.
2. "Open" ile `spaceShooter` klasörünü seçin.
3. Proje yüklendikten sonra `Assets/Scenes` içindeki ana sahneyi açın.

#### Kontroller (Masaüstü)
- WASD veya Yön Tuşları: Hareket
- Space veya Sol Tık: Ateş
- Escape: Duraklat/Menü (varsa)

Gamepad (varsa):
- Sol Çubuk / D-Pad: Hareket
- Güney Tuşu (A / Cross): Ateş
- Start/Menu: Duraklat

Mobil:
- `Assets/Joystick Pack` içindeki ekrandaki joystick hareketi sağlar
- Ekrandaki ateş butonu (varsa) ateş etmeyi sağlar

#### Derleme (Build)
- Android: File → Build Settings → Android → Switch Platform → Build. Örnek APK'lar `oyun/` klasöründedir.
- Masaüstü: File → Build Settings → PC, Mac & Linux Standalone → Build.

#### Proje Yapısı (önemli klasörler)
- `Assets/Scripts`: Oyun kodları
- `Assets/Prefabs`: Yeniden kullanılabilir objeler
- `Assets/Sprites`: Görsel varlıklar
- `Assets/Sounds`: Ses varlıkları
- `Assets/Scenes`: Sahne dosyaları
- `Assets/Joystick Pack`: Mobil joystick varlıkları

#### Notlar
- Girdi eşlemeleri `Assets/InputSystem_Actions.inputactions` dosyasında tanımlıdır ve `Assets/InputSystem_Actions.cs` dosyasına üretilir.
- Girdi çalışmıyorsa: Edit → Project Settings → Player → Active Input Handling: Input System Package olduğundan emin olun.

#### Lisans ve Teşekkür
- Joystick Pack: Fenerax Studios (lisans şartlarına bakınız)



