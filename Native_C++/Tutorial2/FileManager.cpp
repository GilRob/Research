#include "FileManager.h"

//This function will write the saved values to a text file
void FileManager::WriteFile(Vec3 vec)
{
	//Open the file
	write.open("save.txt", std::ofstream::app);
	//If the file is open
	if (write.is_open())
	{
		//Write each value to the file
		write << vec.x << "\n";
		write << vec.y << "\n";
		write << vec.z << "\n";
		write << vec.id << "\n";

		//Close the file
		write.close();
	}

	size++;
}

//This function will read the text file and assign the saved values to the players position
void FileManager::ReadFile(std::string fileName)
{
	float posVal;
	std::string line;
	//Open the file
	read.open(fileName);

	myVecs = new Vec3[size];

	Vec3 temp;

	int posCounter = 0;
	int arrCounter = 0;

	//If the file is open
	if (read.is_open())
	{
		//Go through each line in the file
		while (std::getline(read, line))
		{
			//Tell where the file should read from

			//Go through each line in the file and covert the string of the number into a float
			if (posCounter == 0)
			{
				posVal = std::stof(line);
				setX(posVal);
				temp.x = posVal;
			}
			else if (posCounter == 1)
			{
				posVal = std::stof(line);
				setY(posVal);
				temp.y = posVal;
			}
			else if (posCounter == 2)
			{
				posVal = std::stof(line);
				setZ(posVal);
				temp.z = posVal;
			}
			else if (posCounter == 3)
			{
				posVal = std::stof(line);
				temp.id = posVal;
			}
			//Increment the counter to assign the values to the next variable
			posCounter++;
			//Check if gotten all three values
			if (posCounter > 3)
			{
				//Reset this counter
				posCounter = 0;
				//Add the temp to the vector
				myVecs[arrCounter] = temp;
				//Increment the counter for the array
				arrCounter++;
			}
		}
		//Close the file
		read.close();
	}
}

//Saves the values to variables and calls the writer
void FileManager::SavePosition(float posX, float posY, float posZ, float id)
{
	Vec3 tempVec;
	//Store the values passed into the variables
	setX(posX);
	setY(posY);
	setZ(posZ);

	tempVec.x = posX;
	tempVec.y = posY;
	tempVec.z = posZ;
	tempVec.id = id;

	//Call the file writer
	WriteFile(tempVec);
}

//Calls the reader
Vec3* FileManager::LoadPosition()
{
	ReadFile("save.txt");

	return myVecs;
}

void FileManager::setX(float posX)
{
	X = posX;
}

void FileManager::setY(float posY)
{
	Y = posY;
}

void FileManager::setZ(float posZ)
{
	Z = posZ;
}

float FileManager::getX()
{
	return X;
}

float FileManager::getY()
{
	return Y;
}

float FileManager::getZ()
{
	return Z;
}
