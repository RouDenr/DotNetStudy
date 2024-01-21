﻿namespace ServerModel.XmlParser.Data;

[Serializable]
public class XmlData(string path, string from, string to, string text, int color, byte[]? image) 
	: IData
{
	public string Path { get; set; } = path;
	public string From { get; set; } = from;
	public string To { get; set; } = to;
	public string Text { get; set; } = text;
	public int Color { get; set; } = color;
	public byte[]? Image { get; set; } = image;
	
	
	
	public IData Clone()
	{
		return new XmlData(Path, From, To, Text, Color, Image);
	}
}