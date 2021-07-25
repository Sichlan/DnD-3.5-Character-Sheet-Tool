﻿using CharacterCreator.Core;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace CharacterCreator.MVVM.Model
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class RecentlyUsedCharacterEntry
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string PreviewInfo { get; set; }
        public DateTime LastUpdate { get; set; }
        public Color LeftColor { get; set; }
        public Color? RightColor { get; set; }

        [JsonIgnore]
        public RelayCommand LoadSelectedCharacter
        {
            get
            {
                RelayCommand relayCommand = new RelayCommand(x =>
                    {
                        Character.SetActiveCharacter(FolderPath, FileName);
                    });

                return relayCommand;
            }
        }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(LeftColor), nameof(RightColor))]
        public LinearGradientBrush Background
        {
            get
            {
                var output = new LinearGradientBrush()
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 2)
                };
                output.GradientStops.Add(new GradientStop(LeftColor, 0));
                output.GradientStops.Add(new GradientStop(RightColor == null ? GetComplementaryColor(LeftColor) : RightColor.Value, 1));

                return output;
            }
        }

        public RecentlyUsedCharacterEntry()
        {
            Random rn = StaticRandomizer.GetStaticRandom();

            int colorInt = rn.Next(0, 72);

            LeftColor = GetColorFromStandardColorsByInt(colorInt);
            RightColor = GetComplementaryColor(LeftColor);
        }

        private Color GetComplementaryColor(Color color)
        {
            //https://www.quora.com/Whats-the-algorithm-for-obtaining-a-hexadecimal-colors-opposite-in-the-color-wheel
            byte r = (byte)((color.R + 180) % 360),
                g = (byte)((color.G + 180) % 360),
                b = (byte)((color.B + 180) % 360);

            return Color.FromArgb(255, r, g, b);
        }

        private Color GetColorFromStandardColorsByInt(int colorInt)
        {
            Type type = typeof(Brushes);
            PropertyInfo[] colors = type.GetProperties();
            BrushConverter brushConverter = new BrushConverter();

            return (Color)ColorConverter.ConvertFromString((brushConverter.ConvertFromString(colors[colorInt].Name) as Brush).ToString());
        }

        public override bool Equals(object obj)
        {
            return obj is RecentlyUsedCharacterEntry entry &&
                   FolderPath == entry.FolderPath &&
                   FileName == entry.FileName &&
                   Name == entry.Name &&
                   PreviewInfo == entry.PreviewInfo &&
                   LastUpdate == entry.LastUpdate;
        }

        /// <summary>
        /// Autogenerated by Visual Studio
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 1640209775;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FolderPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FileName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PreviewInfo);
            hashCode = hashCode * -1521134295 + LastUpdate.GetHashCode();
            return hashCode;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }


    }
}
