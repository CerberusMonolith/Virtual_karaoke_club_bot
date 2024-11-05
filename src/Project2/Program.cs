using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("7233936821:AAGHw8BAM1hwwD_x3hjwTaxcY9aXVhoqlWM", cancellationToken: cts.Token);
var me = await bot.GetMeAsync();
var userNames = new Dictionary<long, string>();

Console.WriteLine($"@{me.Username} запущен... Нажмите Enter чтобы выключить");

bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync);

Console.ReadLine();
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Type == UpdateType.Message)
    {
        await OnMessage(update.Message);
    }
    else if (update.Type == UpdateType.CallbackQuery)
    {
        await OnCallbackQuery(update.CallbackQuery);
    }
}

async Task OnMessage(Message msg)
{
    if (msg.Text == null)
        return;

    if (!userNames.ContainsKey(msg.Chat.Id))
    {
        if (msg.Text == "/start")
        {
            await bot.SendTextMessageAsync(msg.Chat.Id, "Добро пожаловать в виртуальный караоке-клуб \"Спой и забудь\"\r\n! Введите ваше имя:");
            return;
        }

        userNames[msg.Chat.Id] = msg.Text;
        await bot.SendTextMessageAsync(msg.Chat.Id, $"Спасибо, {msg.Text}! Для начала напишите 'песня', чтобы узнать о доступных вариантах.");
        return;
    }

    var userName = userNames[msg.Chat.Id];

    if (msg.Text.ToLower() == "песня")
    {
        await bot.SendTextMessageAsync(msg.Chat.Id, "Выберите песню:\n1. Юность в сапогах\n2. Снова Я Напиваюсь\n3. Feel Good Inc",
            replyMarkup: new InlineKeyboardMarkup(new[]
        {
            InlineKeyboardButton.WithCallbackData("1"),
            InlineKeyboardButton.WithCallbackData("2"),
            InlineKeyboardButton.WithCallbackData("3"),
            InlineKeyboardButton.WithCallbackData("Помощь"),
        }));
    }
    else if (msg.Text.ToLower() == "проверка")
    {
        await bot.SendTextMessageAsync(msg.Chat.Id, $"{userName}, проверка бота: работа корректна");
    }
}

async Task OnCallbackQuery(CallbackQuery query)
{
    await bot.AnswerCallbackQueryAsync(query.Id);

    if (query.Data == "1")
    {
        await bot.SendTextMessageAsync(query.Message.Chat.Id, "\r\n\r\n[Интро]\r\nА поехали\r\n\r\n[Куплет 1]\r\nЗдравствуй, fisting в облаках\r\nDungeon Master в сапогах\r\nПропади, моя next door\r\nВот он я, that turns me on\r\nЭх, рельсы fucking slaves\r\nYour finger in my ass\r\nЗдесь do anal на гражданке\r\nНа какой-нибудь the spanking\r\nDick снаружи и с изнанки\r\nСам попробуй изучи\r\nDo you like what do you see? (Вам-пам-па-па-рам-па-ра-па)\r\nНепросто быть собой\r\nКогда шагает boy\r\nТолько master птицей бьётся\r\nFucking cumming, и смеется\r\nИ ему не удаётся\r\nFisting is 300 bucks\r\nDungeon master контрабас (Вам-пам-па-рам-па-ра-пам)\r\n\r\n[Припев]\r\nГде-то течёт my cum\r\nГде-то door, где всё ждут fucking slaves\r\nЭто fuck you слегка\r\nПросто finger щекочет my ass\r\nГде-то течёт my cum\r\nГде-то door, где всё ждут fucking slaves\r\nЭто fuck you слегка\r\nПросто finger щекочет my ass\r\nSee upcoming rock shows\r\nGet tickets for your favorite artists\r\nYou might also like\r\nСайфер 2 (Могу Купить РЗТ) (Cypher)\r\nOG Buda, unki, Toxi$ & SIDODGI DUBOSHIT\r\nПервомай (May Day)\r\nВалентин Стрыкало (Valentin Strikalo)\r\nБотиночки (Boots)\r\nOG Buda & Voskresenskii\r\n[Куплет 2]\r\nFuck вперёд и cum назад\r\nIt's a bondage, gay website\r\nПросто сбросил я two blocks\r\nСловно six hot loads\r\nНа стыках fucking deep\r\nIn ass вбивают dick\r\nТы поймёшь, как fucking cumming\r\nГде full master, а где fucking\r\nГде карьера, а где sex\r\nИ как college boy, oh yes!\r\nКак обманчива my ass\r\nСколько cum и сколько sucking\r\nСколько semen, fisting, fuck\r\nИ как мало hundred bucks\r\n\r\n[Аутро]\r\nИзвиняюсь\r\n\r\n\r\n\r\n.");
    }
    else if (query.Data == "2")
    {
        await bot.SendTextMessageAsync(query.Message.Chat.Id, "\r\n\r\n[Куплет 1]\r\nА ты считаешь ♂bucks♂ в моём кошельке\r\nИ ты любишь только ♂fistin'♂, меня не совсем\r\nИ я вижу, как ты смотришь на ♂fuckin' slaves♂\r\nУ кого есть своя ♂anal, finger, semen♂\r\nА я? Что я? Что я?\r\n\r\n[Припев]\r\nСнова я ♂fuckin' cummin'♂, снова говорю «♂fuck you!♂» (У)\r\nМы не ♂swallow semen♂, у меня пустой ♂fat cock♂\r\nСнова я ♂fuckin' cummin'♂, снова говорю «♂fuck you!♂»\r\nМы с тобой не будем никогда, ♂play with dick♂, никогда\r\n\r\n[Куплет 2]\r\nСлушай, я ♂suck dick♂, что захочешь\r\nСлушай, и, может, даже ♂fistin'♂\r\nСуммы, проси любые суммы\r\nЛюбишь, надеюсь ♂latex♂ любишь\r\n♂Take it, boy!♂ Я, я, ♂ahr-ahr (Ahr-ahr)♂, я давно всё понял (Ага)\r\nНе нужен я, нужны ♂wee-wee, suction, Billy♂\r\nБудут ♂wee-wee♂, обещаю, ♂get your ass back here♂\r\nИ я ♂в'lube'люсь♂, я ♂в'lube'люсь♂ в ♂your ass♂ по новой\r\n\r\n[Припев]\r\nСнова я ♂fuckin' cummin'♂, снова говорю «♂fuck you!♂» (У)\r\nМы не ♂swallow semen♂, у меня пустой ♂fat cock♂\r\nСнова я ♂fuckin' cummin'♂, снова говорю «♂fuck you!♂»\r\nМы с тобой не будем никогда, ♂play with dick♂, никогда\r\nSee upcoming pop shows\r\nGet tickets for your favorite artists\r\nYou might also like\r\nЮность в сапогах (Gachi Version) (Youth in boots)\r\nOsterMine\r\nEuropapa\r\nJoost\r\n​далеко (большой Бушизм) [far]\r\nBUSHIDO ZHO\r\n[Аутро]\r\nНикогда, никогда, никогда.");
    }
    else if (query.Data == "3")
    {
        await bot.SendTextMessageAsync(query.Message.Chat.Id, "Billy ♂two blocks♂ down on a master back\r\nThey just have to go 'cause\r\nthey don't know ♂fuck♂\r\nSo while you fill ♂the gym♂\r\nit's appealing ♂to see♂\r\nYou won't get undercounted\r\n'cause you're dammed and free\r\n\r\nYou got a ♂dungeon master♂\r\nit's ephemeral ♂sex♂\r\nA melancholy ♂gym♂\r\nwhere we ♂fisting ass♂\r\nAnd all I wanna hear\r\n\"♂I't so fucking deep♂\"\r\nMy dreams, they got a ♂spanking♂\r\n'cause I don't get sleep, no\r\n\r\n\r\n♂I'm sorry♂\r\n♂Do you like my two fat cocks♂\r\n♂Fisting is 300 bucks♂\r\n♂Do you like amazing sex?♂\r\n♂Stick your finger in my ass♂\r\n♂I't so fuckin deep, my master♂\r\n♂That's amazing!♂\r\n♂Thanks your, sir!♂\r\n♂Do you like three hundred anal?♂\r\n♂Master...♂\r\n♂ASS WE CAN!!!♂\r\n\r\n\r\nLaughin' gas these hazmat\r\nfast ♂sex♂\r\nLinin' 'em up like ♂ass cracks♂\r\n♂Dungeon master♂ at the track\r\nIt's my ♂fuckin♂ dark attack\r\n\r\nShit , I'm steppin'\r\nin the heart of this here\r\n♂Care Boss♂ rapping' in harder this year\r\nWatch me I am ♂spanking ass♂,\r\nAh-ah-ah-ah-aaaah!\r\n\r\nYo , er gon' ♂gym♂ town this ♂Boy♂town\r\nWith yo' sound, you in the ♂stick♂\r\nGon' bite the dust\r\ncan't fight with us\r\nWith yo' sound\r\nyou ♂suck some dick♂\r\n\r\nSo ♂don't stop♂\r\nget it, get it\r\nUntil you're cheddar head\r\nWatch me I am ♂fuckin slave♂\r\nAh-ah-ah-ah-aaaah!\r\n\r\n\r\n♂Fuck you♂\r\n♂Fuck you♂\r\n♂Fuck you♂\r\n\r\n♂Do you like my two fat cocks\r\n♂Fisting is 300 bucks\r\n♂Do you like amazing sex?\r\n♂Stick your finger in my ass\r\n♂I't so fuckin deep, my master\r\n♂That's amazing!\r\n\r\nThanks your, sir!\r\n♂Do you like 300 anal?\r\n♂Master...♂\r\n♂ASS WE CAN!!!♂\r\n\r\n♂Don't stop♂, get it , get it\r\nPeep how your ♂master♂ in it\r\nSteady, watch me navigate\r\nAh-ah-ah-ah-aaaah!\r\n♂Don't stop♂\r\nget it, get it\r\nPeep how your ♂master♂ in it\r\nSteady, watch me navigate\r\nAh-ah-ah-ah-aaaah!\r\n\r\n♂Fuck you♂\r\n♂Fuck you♂\r\n♂Fuck you♂\r\n♂Fuck you♂.");
    }
    else if (query.Data == "Помощь")
    {
        await bot.SendTextMessageAsync(query.Message.Chat.Id, "Для выбора песни вам нужно выбрать её. Напишите 'песня', чтобы начать.");
    }
}

async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    Console.WriteLine(exception);
}