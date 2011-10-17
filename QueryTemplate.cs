using System;
using Mooege.Net.GS.Message;
using System.Collections.Generic;
using GameMessageViewer;
using System.Linq;
using System.Linq.Dynamic;

public class QueryTemplate<T> where T : GameMessage
{
    public IEnumerable<MessageNode> Query(List<MessageNode> nodes, string whereClause) 
    {
        List<T> messages = new List<T>();
        foreach (MessageNode n in nodes)
            if (n.gameMessage is T)
                messages.Add((T)n.gameMessage);

        IEnumerable<T> result = messages.AsQueryable<T>().Where(whereClause);

        foreach (T message in result)
            yield return new MessageNode(message, 0, 0);
    }
}