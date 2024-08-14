using System.Net;

namespace Comix.Core.Helpers;

public class SnowflakeIdGenerator
{
    private long workerId;
    private long datacenterId;
    private long sequence = 0L;
    private const long WorkerIdBits = 2; // 4 worker IDs (0-3)
    private const long DatacenterIdBits = 2; // 4 datacenter IDs (0-3)
    private const long MaxWorkerId = -1L ^ (-1L << (int)WorkerIdBits);
    private const long MaxDatacenterId = -1L ^ (-1L << (int)DatacenterIdBits);
    private const long SequenceBits = 6; // 64 unique sequences (0-63)
    private const long WorkerIdShift = SequenceBits;
    private const long DatacenterIdShift = SequenceBits + WorkerIdBits;
    private const long TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;
    private const long SequenceMask = -1L ^ (-1L << (int)SequenceBits);
    private long lastTimestamp = -1L;

    private Random random = new Random();

    public SnowflakeIdGenerator()
    {
        workerId = (long)random.Next(0, (int)MaxWorkerId + 1);
        datacenterId = (long)random.Next(0, (int)MaxWorkerId + 1);

        // Validate workerId and datacenterId
        if (workerId > MaxWorkerId || workerId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(workerId), $"Worker ID must be between 0 and {MaxWorkerId}");
        }
        if (datacenterId > MaxDatacenterId || datacenterId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(datacenterId), $"Datacenter ID must be between 0 and {MaxDatacenterId}");
        }
    }

    public long NextId()
    {
        lock (this)
        {
            long timestamp = GetCurrentTimestamp();

            if (timestamp < lastTimestamp)
            {
                throw new Exception("Clock moved backwards. Refusing to generate ID");
            }

            if (timestamp == lastTimestamp)
            {
                sequence = (sequence + 1) & SequenceMask;
                if (sequence == 0)
                {
                    timestamp = WaitForNextTimestamp(lastTimestamp);
                }
            }
            else
            {
                sequence = 0;
            }

            lastTimestamp = timestamp;

            long id = ((timestamp << (int)TimestampLeftShift) |
                      (datacenterId << (int)DatacenterIdShift) |
                      (workerId << (int)WorkerIdShift) |
                      sequence);

            return id;
        }
    }

    private long GetCurrentTimestamp()
    {
        return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
    }

    private long WaitForNextTimestamp(long lastTimestamp)
    {
        long timestamp = GetCurrentTimestamp();
        while (timestamp <= lastTimestamp)
        {
            timestamp = GetCurrentTimestamp();
        }
        return timestamp;
    }

    private string GetMachineIPAddress()
    {
        // You need to implement code to obtain the machine's IP address here.
        // This can vary depending on the specific networking setup and platform.
        // For simplicity, you can use a local IP address like "127.0.0.1" for testing.
        return Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault()?.ToString() ?? "127.0.0.1";
    }

    private long[] ParseIPToIds(string ipAddress)
    {
        // This is a simple example of parsing the IP address.
        // You may need to adjust this logic to match your specific use case.
        string[] parts = ipAddress.Split('.');
        if (parts.Length != 4)
        {
            throw new Exception("Invalid IP address format");
        }

        long workerId = long.Parse(parts[2]);
        long datacenterId = long.Parse(parts[3]);

        return new long[] { workerId, datacenterId };
    }
}