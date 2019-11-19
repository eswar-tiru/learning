from os import listdir
from os.path import isfile, join


def getTime(elem):
    return elem["Time"]


location = "TW LOGS FOR DEV"
logData = []
groupIdentifier = "TradeWinds RUN Group: "
for filename in listdir(location):
    print("Processing file ", filename)
    logfile = open(join(location, filename), "r")
    groupName = ""
    for fileline in logfile:

        if "WAITING" in fileline:
            continue

        if groupIdentifier in fileline:
            groupName = fileline.rstrip().partition(groupIdentifier)[2]
            continue

        if "Success(" in fileline and "Transform" in fileline:
            data = fileline.rstrip().split(" | ");
            logData.append({"FileName": filename, "Group": groupName, "Process Name": data[2], "Time": float(data[1].split()[0])})

logData.sort(key=getTime, reverse=True)
for x in range(10):
    print(logData[x])


