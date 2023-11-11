//завдання 6

/*
Створити систему для управління домашнім кінотеатром, використовуючи шаблон "Фасад". Система має включати наступні компоненти:

AudioSystem : Управління звуком.
VideoPlayer : Відтворення та зупинка відео.
Lighting : Регулювання освітлення.

Фасад  надає два методи:
WatchMovie: Налаштовує аудіосистему, відеоплеєр та освітлення для перегляду фільму.
EndMovie: Вимикає аудіосистему та відеоплеєр, відновлює освітлення.
*/



using System;

namespace FactoryMethod.HomeTheater
{
    class MainApp
    {
        static void Main()
        {
            var homeTheaterFactory = new HomeTheaterFactory();

            // Створюємо компоненти за допомогою фабрики
            var audioSystem = homeTheaterFactory.CreateAudioSystem();
            var videoPlayer = homeTheaterFactory.CreateVideoPlayer();
            var lighting = homeTheaterFactory.CreateLighting();

            // Створюємо домашній кінотеатр
            var homeTheater = new HomeTheater(audioSystem, videoPlayer, lighting);

            homeTheater.WatchMovie();
            homeTheater.EndMovie();

            Console.Read();
        }
    }

    abstract class ComponentFactory
    {
        public abstract AudioSystem CreateAudioSystem();
        public abstract VideoPlayer CreateVideoPlayer();
        public abstract Lighting CreateLighting();
    }

    class HomeTheaterFactory : ComponentFactory
    {
        public override AudioSystem CreateAudioSystem() => new AudioSystem();
        public override VideoPlayer CreateVideoPlayer() => new VideoPlayer();
        public override Lighting CreateLighting() => new Lighting();
    }

    class HomeTheater
    {
        private AudioSystem audioSystem;
        private VideoPlayer videoPlayer;
        private Lighting lighting;

        public HomeTheater(AudioSystem audio, VideoPlayer video, Lighting lights)
        {
            audioSystem = audio;
            videoPlayer = video;
            lighting = lights;
        }

        public void WatchMovie()
        {
            Console.WriteLine("Get ready to watch a movie");
            lighting.Dim();
            audioSystem.TurnOn();
            videoPlayer.Play();
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting movie theater down");
            videoPlayer.Stop();
            audioSystem.TurnOff();
            lighting.Restore();
        }
    }

    class AudioSystem
    {
        public void TurnOn() => Console.WriteLine("AudioSystem is turned on");
        public void TurnOff() => Console.WriteLine("AudioSystem is turned off");
    }

    class VideoPlayer
    {
        public void Play() => Console.WriteLine("VideoPlayer starts playing");
        public void Stop() => Console.WriteLine("VideoPlayer stops playing");
    }

    class Lighting
    {
        public void Dim() => Console.WriteLine("Lights are dimmed");
        public void Restore() => Console.WriteLine("Lights are back to normal");
    }
}
